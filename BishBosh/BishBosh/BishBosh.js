// Uppgift 1
function Uppgift1() {
    for (var i = 1; i < 101; i++) {
        if (i % 3 == 0 && i % 4 == 0) {
            document.write("Bish-Bosh,");
        }
        else if (i % 3 == 0) {
            document.write("Bish,");
        }
        else if (i % 4 == 0) {
            document.write("Bosh,");
        }
        else {
            document.write(i + ",");
        }
    }
}

// Uppgift 2
function Uppgift2(bish, bosh, max) {
    var toPrint = "";

    if (isNaN(bish) || bish === "") {
        return "A number is required";
    }
    if (isNaN(bosh || bosh === "")) {
        return "A number is required";
    }
    if (isNaN(max) || max === "") {
        return "A number is required";
    }

    for (var i=1; i<=max; i++) {
        if (i % bish == 0 && i % bosh == 0) {
            toPrint += "Bish-Bosh,";
        }
        else if (i % bish == 0) {
            toPrint += "Bish,";
        }
        else if (i % bosh == 0) {
            toPrint += "Bosh,";
        }
        else {
            toPrint += i + ",";
        }
    }

    return toPrint;
}

function isPositive(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode;
    var res = String.fromCharCode(charCode);

    return parseInt(res) > 0;
}