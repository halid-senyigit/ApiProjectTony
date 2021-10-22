var viewGetCountryComponent = function (params) {

    let self = {}

    self = $.extend({
        selector: '#viewGetCountryComponent'
    }, params);

    function insertDocument(obj) {
        Object.keys(obj)
            .forEach(function eachKey(key) {
                $(self.selector).find("#countries").append(obj[key].country).append("<br/>");
            });
    }

    self.getCountries = (_region) => {
        let getData = {
            region: _region
        }
        $.ajax({
            url: "/api/CountryApi/GetCountryByRegion",
            data: getData,
            type: "GET", dataType: "json",
            success: function (result, textStatus, jqXHR) {
                if (result.status == true) {
                    var a = JSON.parse(result.data);
                    insertDocument(a.data);
                } else {
                    alert("an error occured: ", result.message);
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert("(" + jqXHR.status + ") " + jqXHR.statusText + "\n" + this.url);
            }
        });
    }


    self.prepare = function () {
        console.log("GetCountryComponent prepared");
        
    }

    return self;
}
