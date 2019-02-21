$(document).ready(function () {
    $('#add').click(function () {
        //validation and add order items
        var isAllValid = true;

        if (isAllValid) {
            var $newRow = $('#mainrow').clone().removeAttr('Id');
            $('.ir', $newRow).val($('#Restaurants').val());
            $('.product', $newRow).val($('#Products').val());
            $('.quantity', $newRow).val($('#Quantity').val());
            $('.price', $newRow).val($('#Price').val() * $('#Quantity').val());

            //Replace add button with remove button
            $('#add', $newRow).addClass('remove').val('Remove').removeClass('btn-success').addClass('btn-danger');

            //remove id attribute from new clone row
            $('#itemSupplier,#item,#quantity,#add', $newRow).removeAttr('Id');
            $('span.error', $newRow).remove();
            //append clone row
            $('#orderdetailsItems').append($newRow);

            //clear select data
            $('#itemSupplier,#item').val('0');
            $('#quantity').val('');
            $('#orderItemError').empty();
        }
    });

    LoadRestaurantCombo();
    LoadCinemaCombo();
    $('#table').DataTable({
        "ajax": LoadIndexProduct()
    });
});

function LoadCinemaCombo() {
    $.ajax({
        url: 'http://localhost:17940/api/Cinemas',
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            var cinema = $('#Cinemas');
            cinema.empty();
            cinema.append($('<option/>').val('0').text('Select'));
            $.each(result, function (i, Cinema) {
                $("<option></option>").val(Cinema.Id).text(Cinema.Name).appendTo(cinema);
            });
        }
    });
}

function LoadProduct() {
    $.ajax({
        url: 'http://localhost:17940/api/Products/GetProduct/' + $('#Cinemas').val(),
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
                html += '<td>' + val.Price + '</td>';
                html += '<td>' + val.Restaurants.Name + '</td>';
                html += '</tr>';
                i++;
            });
            $('.tbody').html(html);
        }
    });
}

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
                html += '<td>' + val.Price + '</td>';
                html += '<td>' + val.Restaurants.Name + '</td>';
                html += '<td> <a href="#" onclick="return GetById(' + val.Id + ');">Edit</a> ';
                html += '</tr>';
                i++;
            });
            $('.tbody').html(html);
        }
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
            $('#Price').val(result.Price);
            $('#Restaurants').val(result.Restaurants.Name);

            $('#myModal').modal('show');
            $('#Save').hide();
            $('#Update').show();
        }
    })
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

function LoadProductByRestaurant() {
    $.ajax({
        url: 'http://localhost:17940/api/Products/GetProductByRestaurant/' + $('#Restaurants').val(),
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