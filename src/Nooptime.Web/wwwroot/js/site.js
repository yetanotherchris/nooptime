document.addEventListener("DOMContentLoaded",
    function (event) {
        var vm = new Vue(
            {
                el: "#vue-instance",
                data: {
                    items: []
                },
                created: function () {
                    var that = this;

                    axios.get("/api/UptimeCheck/GetAll")
                        .then(function (response) {
                            // Replace the data
                            // See https://vuejs.org/v2/guide/list.html#Replacing-an-Array
                            that.items = that.items.concat(response.data);
                        })
                        .catch(function (error) {
                            console.log(error);
                        });
                },
                methods: {
                    add: function () {
                        var that = this;

                        var model = {
                            Name: document.getElementById("name").value,
                            Description: document.getElementById("description").value,
                            Interval: document.getElementById("interval").value,
                            Properties: []
                        };

                        axios.post("/api/UptimeCheck", model)
                            .then(function (response) {
                                that.items.push(model);
                                console.log(response);
                            })
                            .catch(function (error) {
                                console.log(error);
                            });
                    },

                    remove: function (index) {
                        var that = this;
                        that.items.splice(index, 1);
                        //var id = that.index;

                        //axios.delete("/api/values/delete", id)
                        //    .then(function(response) {
                        //        that.items.splice(id);
                        //        console.log(response);
                        //    })
                        //    .catch(function(error) {
                        //        console.log(error);

                        //    });
                    }
                }
            });
    });
