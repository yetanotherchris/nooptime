class UptimeCheckService {
    
    constructor(endPointPath) {
        this.endpointPath = endPointPath;
        this.axios = require("axios");
    }

    getSummaryData() {
        
        this.axios.default.get("/api/UptimeCheck/GetAll")
            .then(function (response) {
                console.log(response);
                return response.data;
            })
            .catch(function (error) {
                console.log(error);
            });
    }
}

/* var tempAxios = require("axios");
tempAxios.default.post("/api/UptimeCheck/Post", {
    Name :"test item",
    Description : "test description",
    Interval : "0"
});
*/
var x = new RestUptimeCheckService("foo");
var data = x.getSummaryData();
console.log(data); 