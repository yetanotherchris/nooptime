document.addEventListener("DOMContentLoaded",
    function (event) {
        Vue.config.devtools = true;

        Vue.component('test', {
            template: '<p>test</p>',
            data: function () {

            }
        });


        var vm = new Vue(
            {
                el: "#vue-instance",
                data: {
                    items: []
                },
                created: function () {
                    var that = this;

                    //axios.get("/api/UptimeCheck/GetAll")
                    //    .then(function (response) {

                    //        // Replace the data
                    //        // See https://vuejs.org/v2/guide/list.html#Replacing-an-Array
                    //        that.items = that.items.concat(response.data);
                    //    })
                    //    .catch(function (error) {
                    //        console.log(error);
                    //    });
                },
                methods: {
                    add: function () {
                        var that = this;

                        if (document.getElementById("addForm").checkValidity()) {
                            var model = {
                                Id: document.getElementById("id").value,
                                Name: document.getElementById("name").value,
                                Description: document.getElementById("description").value,
                                Interval: document.getElementById("interval").value
                            };
                            that.items.push(model);

                            document.getElementById("id").value = "00000000-0000-0000-0000-000000000000";
                            document.getElementById("name").value = "";
                            document.getElementById("description").value = "";
                            document.getElementById("interval").value = "";
                            //axios.post("/api/UptimeCheck/Post", model)
                            //    .then(function (response) {

                            //        console.log(response);
                            //    })
                            //    .catch(function (error) {
                            //        console.log(error);
                            //    });
                        }
                    },

                    remove: function (item, index) {
                        var that = this;
                        that.items.splice(index, 1);
                        //axios.delete("/api/UptimeCheck/Delete", { params: { id: item.id } })
                        //    .then(function (response) {
                               
                        //        console.log(response);
                        //    })
                        //    .catch(function (error) {
                        //        console.log(error);

                        //    });
                    }
                }
            });
    });
