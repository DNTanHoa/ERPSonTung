function onSearchForDataGrid(grid) {
    console.log("#" + grid);
    $("#" + grid).data("kendoGrid").dataSource.read();
    $("#" + grid).data("kendoGrid").refresh();
}

function toDate(dateStr) {
    var parts = dateStr.split("/")
    return new Date(parts[2], parts[1] - 1, parts[0])
}

function toDate02(dateStr) {

    var day;
    var parts1 = dateStr.split("/");
    day = parts1[2] + '/' + parts1[1] + '/' + parts1[0];
    return day;
}

function toDateTime(dateStr) {
    var day;
    var parts = dateStr.split(" ")
    var date = parts[0]
    var time = parts[1]
    var parts1 = date.split("/");
    var parts2 = time.split(":");
    day = parts1[2] + '/' + parts1[1] + '/' + parts1[0] + ' ' + parts[1]
    return day;
}

function stringToDate(date, format, delimeter) {
    var formatLowerCase = format.toLowerCase();
    var formatItems = formatLowerCase.split(delimeter);
    var dateItems = date.split(delimeter);
    var monthIndex = formatItems.indexOf("mm");
    var dayIndex = formatItems.indexOf("dd");
    var yearIndex = formatItems.indexOf("yyyy");
    var month = parseInt(dateItems[monthIndex]);
    var day = parseInt(dateItems[dayIndex]);
    var year = parseInt(dateItems[yearIndex])
    var formatedDate = new Date(year, month - 1, day);
    return formatedDate;
}

function stringToDateDefault(date) {
    var day;
    var parts = date.split("-");
    day = parts[2] + '/' + parts[1] + '/' + parts[0];
    return day
}

function formDataToObject(formID) {
    var form = document.getElementById(formID);
    var obj = {};
    var formData = new FormData(form);
    formData.forEach((value, key) => {
        obj[key] = value;
    })
    return obj;
}