$(document).ready(function () {
    LoadIndexProduct();
    LoadRestaurantCombo();
    hiddenProductAlert();
    $('#table').DataTable({
        "ajax": LoadIndexProduct()
    });
});

function LoadIndexProduct() {
    $.ajax({
        url: 'http://localhost:17940/api/Products',
        type: 'GET',
        async: false,
        dataType: 'json',
        success: function (product) {
            var html = '';
            var i = 1;
            $.each(product, function (index, val) {
                html += '<tr>';
                html += '<td>' + i + '</td>';
                html += '<td>' + val.Name + '</td>';
                html += '<td>' + val.Variety + '</td>';
                html += '<td>' + val.Description + '</td>';
                html += '<td>' + val.Image + '</td>';
                html += '<td>' + val.Price + '</td>';
                html += '<td>' + val.Restaurants.Name + '</td>';
                html += '<td> <a href="#" onclick="return GetById(' + val.Id + ');">Edit</a> ';
                html += '| <a href="#" onclick="return Delete(' + val.Id + ')">Delete</a></td>';
                html += '</tr>';
                i++;
            });
            $('.tbody').html(html);
        }
    });
}

function LoadRestaurantCombo() {
    $.ajax({
        url: 'http://localhost:17940/api/Restaurants',
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            var restaurant = $('#Restaurants');
            restaurant.empty();
            restaurant.append($('<option/>').val('0').text('Select'));
            $.each(result, function (i, Restaurant) {
                $("<option></option>").val(Restaurant.Id).text(Restaurant.Name).appendTo(restaurant);
            });
        }
    });
}

function Save() {
    var product = new Object();
    product.Name = $('#Name').val();
    product.Variety = $('#Variety').val();
    product.Description = $('#Description').val();
    product.Image = $('#Image').val();
    product.Price = $('#Price').val();
    product.Restaurants_Id = $('#Restaurants').val();
    $.ajax({
        url: 'http://localhost:17940/api/Products',
        type: 'POST',
        dataType: 'json',
        data: product,
        success: function (response) {
            swal({
                title: "Saved!",
                text: "That data has been inserted!",
                type: "success"
            },
            function () {
                window.location.href = '/Products/Index/';
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
            url: "http://localhost:17940/api/Products/" + Id,
            type: "DELETE",
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                function () {
                    window.location.href = '/Products/Index/';
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
        url: 'http://localhost:17940/api/Products/' + Id,
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            $('#Id').val(result.Id);
            $('#Name').val(result.Name);
            $('#Variety').val(result.Variety);
            $('#Description').val(result.Description);
            $('#Image').val(result.Image);
            $('#Price').val(result.Price);
            $('#Restaurants').val(result.Restaurants_Id);

            $('#myModal').modal('show');
            $('#Save').hide();
            $('#Update').show();
        }
    })
}

function Edit() {
    var product = new Object();
    product.Id = $('#Id').val();
    product.Name = $('#Name').val();
    product.Variety = $('#Variety').val();
    product.Description = $('#Description').val();
    product.Image = $('#Image').val();
    product.Price = $('#Price').val();
    product.Restaurants_Id = $('#Restaurants').val();
    $.ajax({
        url: 'http://localhost:17940/api/Products/' + product.Id,
        type: 'PUT',
        data: product,
        dataType: 'json',
        success: function (response) {
            swal({
                title: "Updated!",
                text: "your data has been updated!",
                type: "success"
            },
            function () {
                window.location.href = '/Products/Index/';
                $('#Id').val('');
                $('#Name').val('');
                $('#Variety').val('');
                $('#Description').val('');
                $('#Price').val('');
            });
        },
        error: function (response) {
            swal("Oops", "We couldn't connect to the server!", "error");
        }
    });
}

function validateInsertProduct() {
    var allValid = true;
    if ($('#Name').val() == "" || $('#Name').val() == " ") {
        allValid = false;
        $('#Name').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Name').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Variety').val() == "" || $('#Variety').val() == " ") {
        allValid = false;
        $('#Variety').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Variety').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Description').val() == "" || $('#Description').val() == " ") {
        allValid = false;
        $('#Description').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Description').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Image').val() == "" || $('#Image').val() == " ") {
        allValid = false;
        $('#Image').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Image').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Price').val() == "" || $('#Price').val() == " ") {
        allValid = false;
        $('#Price').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Price').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Restaurants').val() == 0 || $('#Restaurants').val() == "0") {
        allValid = false;
        $('#Restaurants').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Restaurants').siblings('span.error').css('visibility', 'hidden');
    }

    if (allValid == true) {
        Save();
    }
}

function validateEditProduct() {
    var allValid = true;
    if ($('#Name').val() == "" || $('#Name').val() == " ") {
        allValid = false;
        $('#Name').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Name').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Variety').val() == "" || $('#Variety').val() == " ") {
        allValid = false;
        $('#Variety').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Variety').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Description').val() == "" || $('#Description').val() == " ") {
        allValid = false;
        $('#Description').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Description').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Image').val() == "" || $('#Image').val() == " ") {
        allValid = false;
        $('#Image').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Image').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Price').val() == "" || $('#Price').val() == " ") {
        allValid = false;
        $('#Price').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Price').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Restaurants').val() == 0 || $('#Restaurants').val() == "0") {
        allValid = false;
        $('#Restaurants').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Restaurants').siblings('span.error').css('visibility', 'hidden');
    }

    if (allValid == true) {
        Edit();
    }
}

function hiddenProductAlert() {
    $('#Name').siblings('span.error').css('visibility', 'hidden');
    $('#Variety').siblings('span.error').css('visibility', 'hidden');
    $('#Description').siblings('span.error').css('visibility', 'hidden');
    $('#Image').siblings('span.error').css('visibility', 'hidden');
    $('#Price').siblings('span.error').css('visibility', 'hidden');
    $('#Restaurants').siblings('span.error').css('visibility', 'hidden');
}

function clearProductScreen() {
    $('#Id').val('');
    $('#Name').val('');
    $('#Variety').val('');
    $('#Description').val('');
    $('#Image').val('');
    $('#Price').val('');
    $('#Restaurants').val(0);
    hiddenProductAlert();
}