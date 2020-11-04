var Gastos = Gastos || {};
Gastos.Home = Gastos.Home || {};

Gastos.Home = (function () {
    "use strict";
    let HomeLoad = function () {
        let Share = Gastos.Share;
        let Controller = "/Home";

        this.initialize = function () {
            Share.ShowAlerts();
            iniCalendar();
            iniButtons();
            changeModalContet();
            chageTypeTrascation();
            validFormAddTransaction();
            validFormAddCategory();
            selectIconCategory();
        };

        //----------------------------------------------------- INDEX
        let iniCalendar = function () {
            //Initialize the calendar in Index
            let calendarItem = document.getElementById("calendarioHome");

            let calendar = new FullCalendar.Calendar(calendarItem, {
                cursor: "pointer",
                plugins: ["dayGrid", "bootstrap"],                
                themeSystem: "bootstrap",
                locale: "es",
                customButtons: {
                    addTransaction: {
                        text: "Transacción",
                        click: function () {
                            addTransaction();
                        },
                    }
                },
                header: {
                    left: "title",
                    center: "",
                    right: "addTransaction prev,next",
                },
                events: {
                    url: `${Controller}/ExpensesDay`,
                    method: "POST",
                },
                eventClick: lstExpensesDetails,
            });

            calendar.render();
            balance();
        };

        let iniButtons = function () {
            //Sets mask on the inputs
            $(".input-numeric").maskMoney();
            $(".input-date").datepicker();
        };

        let addTransaction = function () {
            //Display modal with form to add a Transaction/Category
            $("#sctAddCategory").hide();
            $("#sctAddTransaction").show();
            $("#frmAddTransaction")[0].reset();
            $("#sltTypeTransaction").val("").change();
            $("#modalAddTransacion").modal("show");
        };

        let balance = function () {
            let daysShowed = $(".fc-other-month");
            let totalDays = daysShowed.length;
            let firstDay = daysShowed[0].getAttribute("data-date");
            let lastDay = daysShowed[totalDays - 1].getAttribute("data-date");
            $.ajax({
                method: "POST",
                url: `${Controller}/Balance`,
                data: { start: firstDay, end: lastDay },
            }).done(function (response) {
                $("#lblDeposits").text(Share.FormatCurrency(response.deposit));
                $("#lblExpenses").text(Share.FormatCurrency(response.expense));
                $("#dvBalance")
                    .removeClass("alert alert-dark")
                    .addClass(response.cssClass);
                $("#lblBalance").text(Share.FormatCurrency(response.balanceMoney));
            });

            $(".fc-prev-button, .fc-next-button, .fc-today-button").click(
                function () {
                    balance();
                }
            );
        };

        let lstExpensesDetails = function (info) {
            let date = moment(info.event.start).format("DD/MM/YYYY");
            $.ajax({
                method: "POST",
                url: `${Controller}/ExpensesDayDetails`,
            }).done(function (response) {
                $("#spnDateDetails").text(date);
                $("#modalBodyExpensesDetails").html("");
                $("#modalBodyExpensesDetails").html(response);
                $("#modalDayDetails").modal("show");
                TableDetails(date);
            }); //TODO:y que pasa cuando  falla?
        };

        let TableDetails = function (date) {
            let config = Share.DataTableConfig();
            config.ajax = {
                url: `${Controller}/LstExpensesDay`,
                type: "POST",
                datatype: "json",
                data: { day: date },
            };
            config.columns = [
                {
                    data: "category.name",
                },
                {
                    data: "value",
                    render: function (data, type, row, meta) {
                        return Share.FormatCurrency(data);
                    },
                },
            ];
            config.columnDefs = [
                {
                    targets: 1,
                    createdCell: function (td, cellData, rowData, row, col) {
                        $(td).addClass("text-right");
                    },
                },
            ];
            config.createdRow = function (row, data, dataIndex) {
                if (data.typeTransactionID == 2) {
                    $(row).addClass("table-success-item");
                } else {
                    $(row).addClass("table-danger-item");
                }
            };
            config.footerCallback = function (row, data, start, end, display) {
                if (data.length > 0) {
                    let total = data.reduce((acum, valorActual) => acum + valorActual.value, 0)
                    $(row).children()[1].innerText = Share.FormatCurrency(total);
                    if (total < 0) {
                        $(row).addClass("table-danger");
                    } else {
                        $(row).addClass("table-success");
                    }
                }
            };
            $("#tblExpensesDetails").DataTable(config);
        };

        //----------------------------------------------------- MODAL TRANSACTION / CATEGORY
        let changeModalContet = function () {
            //Display the form Transaction or Category
            $(".changeContent").click(function () {
                $(".sltTypeTransaction").change();
                let addTransaction = $("#sctAddTransaction");
                let addCategory = $("#sctAddCategory");
                if (addTransaction.is(":visible")) {
                    addTransaction.hide();
                    addCategory.show();
                } else {
                    addCategory.hide();
                    addTransaction.show();
                }
            });
        };

        let chageTypeTrascation = function () {
            //Enable or disabled the inputs in the form display (Transaction/Category)
            $(".sltTypeTransaction").change(function () {
                let typeTransaction = $(this).val();
                $(".sltTypeTransaction").val(typeTransaction);
                if (typeTransaction != "") {
                    $.ajax({
                        method: "POST",
                        url: `${Controller}/LstCategoriesByTypeTransaction`,
                        data: { idTypeTransaction: typeTransaction },
                    }).done(function (response) {
                        $("#contentIconsCategory").html("");
                        response.forEach((category) => {
                            createCategoryHTML(category);
                        });
                        selectIconCategory();
                        enableDisabledInputs(true);
                    });
                } else {
                    enableDisabledInputs(false);
                }
            });
        };

        let enableDisabledInputs = function (flag) {
            //Block and unblock inputs
            if (flag) {
                $("#numValue").removeAttr("disabled");
                $("#txtComment").removeAttr("disabled");
                $("#calActionDate").removeAttr("disabled");
                $(".icons-transaction div").removeClass("d-none");
                $(".icons-transaction").removeClass("disabled");
                $("#txtName").removeAttr("disabled");
                $("#btnAddTrasaction").removeClass("d-none");
                $("#btnAddCategory").removeClass("d-none");
            } else {
                $("#numValue").attr("disabled", "disabled");
                $("#txtComment").attr("disabled", "disabled");
                $("#calActionDate").attr("disabled", "disabled");
                $(".icons-transaction div").addClass("d-none");
                $(".icons-transaction").addClass("disabled");
                $("#txtName").attr("disabled", "disabled");
                $("#btnAddTrasaction").addClass("d-none");
                $("#btnAddCategory").addClass("d-none");
            }
        };

        let createCategoryHTML = function (category) {
            //Create an element HTML (Category) with the responde of the Ajax
            let divCategory = document.createElement("div");
            divCategory.className = "icon col-4 p-1 text-center";
            divCategory.setAttribute("data-idcategory", category.iconID);
            let iconCategory = document.createElement("i");
            iconCategory.className = `${category.icon.iconName} d-block`;
            divCategory.append(iconCategory);
            if ($("#sctAddTransaction").is(":visible")) {
                let nameIcon = document.createElement("small");
                nameIcon.innerText = category.name;
                divCategory.append(nameIcon);
            }
            $("#contentIconsCategory").append(divCategory);
        };

        let validFormAddTransaction = function () {
            //Valid the form for new Transaction
            $("#frmAddTransaction").validate({
                rules: {
                    Comment: {
                        maxlength: 25,
                    },
                    Value: {
                        min: 0.01,
                        number: true,
                        normalizer: function (value) {
                            return Share.CleanNumber(value);
                        },
                    },
                },
                submitHandler: function (form) {
                    Share.CleanForm("frmAddTransaction");
                    let idCategory = $("#hdCategory").val();
                    if (idCategory != 0) {
                        form.submit();
                    } else {
                        $("#hdCategory-error").removeClass("d-none");
                        return false;
                    }
                },
            });
        };

        let validFormAddCategory = function () {
            //Valid the form form new Category
            $("#frmAddCategory").validate({
                rules: {
                    Name: {
                        required: true,
                        rangelength: [1, 25],
                    },
                    Icon: {
                        required: true,
                    },
                },
                submitHandler: function (form) {
                    let idIcon = $("#hdIcon").val();
                    if (idIcon != 0) {
                        form.submit();
                    } else {
                        $("#hdIcon-error").removeClass("d-none");
                        $("#hdIcon-error").addClass("d-block");
                        return false;
                    }
                },
            });
        };

        let selectIconCategory = function () {
            //Sets the value in the input hidden for Category in form Transaction
            $(".icon").click(function () {
                let idError = "";
                let idInput = "";
                if ($("#sctAddTransaction").is(":visible")) {
                    idError = "#hdCategory-error";
                    idInput = "#hdCategory";
                } else {
                    idError = "#hdIcon-error";
                    idInput = "#hdIcon";
                }
                $(idError).removeClass("d-block");
                $(idError).addClass("d-none");
                $(".icon").removeClass("selected-class");
                $(this).addClass("selected-class");
                let idCategory = $(this).attr("data-idcategory");
                $(idInput).val(idCategory);
            });
        };
    };

    return new HomeLoad();
})();
(function ($, window, document) {
    "use strict";
    $(function () {
        Gastos.Home.initialize();
    });
})(window.jQuery, window, document);
