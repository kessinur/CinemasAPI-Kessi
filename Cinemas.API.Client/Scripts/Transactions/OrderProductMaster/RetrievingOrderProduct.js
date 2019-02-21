$(document).ready(function () {
    LoadIndexOrderProduct();
    LoadProductCombo();
    LoadReservationCombo();
    hiddenOrderProductAlert();
    $('#table').DataTable({
        "ajax": LoadIndexOrderProduct()
    });
});

function LoadIndexOrderProduct() {
    $.ajax({
        url: 'http://localhost:17940/api/OrderProducts',
        type: 'GET',
        async: false,
        dataType: 'json',
        success: function (orderproduct) {
            var html = '';
            var i = 1;
            $.each(orderproduct, function (index, val) {
                html += '<tr>';
                html += '<td>' + i + '</td>';
                html += '<td>' + val.Quantity + '</td>';
                html += '<td>' + val.Products.Name + '</td>';
                html += '<td>' + val.Reservations.Id + '</td>';
                html += '<td>' + val.Reservations.Users.FirstName + '</td>';
                html += '<td> <a href="#" onclick="return GetById(' + val.Id + ');">Edit</a> ';
                html += '| <a href="#" onclick="return Delete(' + val.Id + ')">Delete</a></td>';
                html += '</tr>';
                i++;
            });
            $('.tbody').html(html);
        }
    });
}

function LoadProductCombo() {
    $.ajax({
        url: 'http://localhost:17940/api/Products',
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            var product = $('#Products');
            product.empty();
            product.append($('<option/>').val('0').text('Select'));
            $.each(result, function (i, Product) {
                $("<option></option>").val(Product.Id).text(Product.Name).appendTo(product);
            });
        }
    });
}

function LoadReservationCombo() {
    $.ajax({
        url: 'http://localhost:17940/api/Reservations',
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            var reservation = $('#Reservations');
            reservation.empty();
            reservation.append($('<option/>').val('0').text('Select'));
            $.each(result, function (i, Reservation) {
                $("<option></option>").val(Reservation.Id).text(Reservation.Id).appendTo(reservation);
            });
        }
    });
}

function Save() {
    var orderproduct = new Object();
    orderproduct.Quantity = $('#Quantity').val();
    orderproduct.Products_Id = $('#Products').val();
    orderproduct.Reservations_Id = $('#Reservations').val();
    $.ajax({
        url: 'http://localhost:17940/api/OrderProducts',
        type: 'POST',
        dataType: 'json',
        data: orderproduct,
        success: function (response) {
            swal({
                title: "Saved!",
                text: "That data has been inserted!",
                type: "success"
            },
            function () {
                window.location.href = '/OrderProducts/Index/';
            });
        },
        error: function (response) {
            swal("Oops", "We couldn't connect to the server!", "error");
        }
    });
}

function Delete(Id) {
    swal({
        title: "Are you sure?",
        text: "You will not be able to recover this imaginary file!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Yes, delete it!",
        closeOnConfirm: false
    }, function () {
        $.ajax({
            url: "http://localhost:17940/api/OrderProducts/" + Id,
            type: "DELETE",
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                function () {
                    window.location.href = '/OrderProducts/Index/';
                });
            },
            error: function (response) {
                swal("Oops", "We couldn't connect to the server!", "error");
            }
        });
    });
}

function GetById(Id) {
    $.ajax({
        url: 'http://localhost:17940/api/OrderProducts/' + Id,
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            $('#Id').val(result.Id);
            $('#Quantity').val(result.Quantity);
            $('#Products').val(result.Products_Id);
            $('#Reservations').val(result.Reservations_Id);

            $('#myModal').modal('show');
            $('#Save').hide();
            $('#Update').show();
        }
    })
}

function validateInsertOrderProduct() {
    var allValid = true;
    if ($('#Quantity').val() == "" || $('#Quantity').val() == " ") {
        allValid = false;
        $('#Quantity').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Quantity').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Products').val() == 0 || $('#Products').val() == "0") {
        allValid = false;
        $('#Products').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Products').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Reservations').val() == 0 || $('#Reservations').val() == "0") {
        allValid = false;
        $('#Reservations').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Reservations').siblings('span.error').css('visibility', 'hidden');
    }

    if (allValid == true) {
        Save();
    }
}

function hiddenOrderProductAlert() {
    $('#Quantity').siblings('span.error').css('visibility', 'hidden');
    $('#Products').siblings('span.error').css('visibility', 'hidden');
    $('#Reservations').siblings('span.error').css('visibility', 'hidden');
}

function clearOrderProductScreen() {
    $('#Id').val('');
    $('#Quantity').val('');
    $('#Products').val(0);
    $('#Reservations').val(0);
    hiddenOrderProductAlert();
}