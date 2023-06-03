const show = document.querySelector('#cre');
                                            const VND = new Intl.NumberFormat('vi-VN', {
                                                style: 'currency',
                                                currency: 'VND',
                                            });
                                            var price = document.getElementsByName('price');
                                            var total = 0;
                                            var ship = 0;
                                            var discount = 0;
                                            for (var i = 0; i < price.length; i++) {
                                                total += Number(price[i].value);
                                            }
                                            var totalfirst = total;
                                            document.getElementById("demo").innerHTML = VND.format(total);
                                            function methodChanged(obj)
                                            {
                                                var cn = document.getElementById("car_number");
                                                var cc = document.getElementById("car_code");
                                                var cm = document.getElementById("car_month");
                                                var cy = document.getElementById("car_year");
                                                var value = obj.value;
                                                if (value === '4') {
                                                    show.style.display = 'block';
                                                    cn.disabled = false;
                                                    cc.disabled = false;
                                                    cm.disabled = false;
                                                    cy.disabled = false;
                                                } else {
                                                    show.style.display = 'none';
                                                    cn.disabled = true;
                                                    cc.disabled = true;
                                                    cm.disabled = true;
                                                    cy.disabled = true;
                                                }
                                            }
                                            ;
                                            var citis = document.getElementById("city");
                                            var districts = document.getElementById("district");
                                            var wards = document.getElementById("ward");
                                            var Parameter = {
                                                url: "/vietnam.json", //Đường dẫn đến file chứa dữ liệu hoặc api do backend cung cấp
                                                method: "GET", //do backend cung cấp
                                                responseType: "application/json", //kiểu Dữ liệu trả về do backend cung cấp
                                            };
                                            //gọi ajax = axios => nó trả về cho chúng ta là một promise
                                            var promise = axios(Parameter);
                                            //Xử lý khi request thành công
                                            promise.then(function (result) {
                                                renderCity(result.data);
                                            });

                                            function renderCity(data) {
                                                for (const x of data) {
                                                    citis.options[citis.options.length] = new Option(x.Name, x.Id);
                                                }


                                                // xứ lý khi thay đổi tỉnh thành thì sẽ hiển thị ra quận huyện thuộc tỉnh thành đó
                                                citis.onchange = function () {
                                                    district.length = 1;
                                                    ward.length = 1;

                                                    if (this.value !== "") {
                                                        const result = data.filter(n => n.Id === this.value);
                                                        for (const k of result[0].Districts) {
                                                            district.options[district.options.length] = new Option(k.Name, k.Id);
                                                        }

                                                    }
                                                    var phiship = document.getElementById("phiship").value;
                                                    if (this.value == "01" || this.value == "79") {
                                                        ship = 25000;
                                                    } else {
                                                        ship = 35000;
                                                    }
                                                    $("#phiship").val(ship);
                                                    totalfirst = (total + ship);
                                                    total = (total + ship) - (total + ship) * discount / 100;

                                                    document.getElementById("ship").innerHTML = VND.format(ship);
                                                    document.getElementById("total").innerHTML = VND.format(total);
                                                };
                                                document.getElementById("total").innerHTML = VND.format(total + ship);
                                                // xứ lý khi thay đổi quận huyện thì sẽ hiển thị ra phường xã thuộc quận huyện đó
                                                district.onchange = function () {
                                                    ward.length = 1;
                                                    const dataCity = data.filter((n) => n.Id === citis.value);
                                                    if (this.value !== "") {
                                                        const dataWards = dataCity[0].Districts.filter(n => n.Id === this.value)[0].Wards;
                                                        for (const w of dataWards) {
                                                            wards.options[wards.options.length] = new Option(w.Name, w.Id);
                                                        }
                                                    }
                                                };
                                            }
                                            ;
                                            var city = "";
                                            var quan = "";
                                            var phuongxa = "";
                                            var adressreal = "";
                                            //Thanh toán nào
                                            $(function () {
                                                $("#city").change(function () {
                                                    city = $("#city option:selected").text();
                                                })
                                            })
                                            $(function () {
                                                $("#district").change(function () {
                                                    quan = $("#district option:selected").text();
                                                })
                                            })
                                            $(function () {
                                                $("#ward").change(function () {
                                                    phuongxa = $("#ward option:selected").text();
                                                })
                                            })

                                            function checkout() {
                                                var adress = document.getElementById("adress").value;
                                                var totalin = document.getElementById("totalreal").value;
                                                var nomal = document.getElementById("nomal").value;
                                                adressreal = adress + ", " + phuongxa + ", " + quan + ", " + city;
                                                totalin = total;
                                                nomal = totalfirst;
                                                $("#adressreal").val(adressreal);
                                                $("#totalreal").val(totalin);
                                                $("#nomal").val(nomal);
                                                return true;
                                            }
                                            ;
                                            function checkgiamgia() {
                                                let noti = "Mã giảm giá không khả dụng";
                                                const show = document.querySelector('#noti');

                                                var magg = document.getElementById("magg").value.toUpperCase();
        <c:forEach items="${sessionScope.discountcode}" var="code">
                                                if (magg === '${code.magg.toUpperCase()}') {
                                                    noti = "Áp thành công mã giảm giá " +${code.rate} + "%";
                                                    discount = ${code.rate};
                                                    total = total - total * discount / 100;
                                                }
        </c:forEach>
                                                show.style.display = 'block';
                                                document.getElementById("noticheck").innerHTML = noti;
                                                document.getElementById("total").innerHTML = VND.format(total);
                                            }
                                            ;
                                            function changemagg() {
                                                const show = document.querySelector('#noti');
                                                show.style.display = 'none';
                                                discount = 0;
                                                total = totalfirst;
                                                document.getElementById("total").innerHTML = VND.format(total);
                                            }