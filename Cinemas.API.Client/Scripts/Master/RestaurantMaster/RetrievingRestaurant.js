$(document).ready(function () {
    LoadIndexRestaurant();
    LoadCinemaCombo();
    hiddenRestaurantAlert();
    $('#table').DataTable({
        "ajax": LoadIndexRestaurant()
    });
});

function LoadIndexRestaurant() {
    $.ajax({
        url: 'http://localhost:17940/api/Restaurants',
        type: 'GET',
        async: false,
        dataType: 'json',
        success: function (restaurant) {
            var html = '';
            var i = 1;
            $.each(restaurant, function (index, val) {
                html += '<tr>';
                html += '<td>' + i + '</td>';
                html += '<td>' + val.Name + '</td>';
                html += '<td>' + val.Description + '</td>';
                html += '<td>' + val.Cinemas.Name + '</td>';
                html += '<td> <a href="#" onclick="return GetById(' + val.Id + ');">Edit</a> ';
                html += '| <a href="#" onclick="return Delete(' + val.Id + ')">Delete</a></td>';
                html += '</tr>';
                i++;
            });
            $('.tbody').html(html);
        }
    });
}

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

function Save() {
    var restaurant = new Object();
    restaurant.Name = $('#Name').val();
    restaurant.Description = $('#Description').val();
    restaurant.Cinemas_Id = $('#Cinemas').val();
    $.ajax({
        url: 'http://localhost:17940/api/Restaurants',
        type: 'POST',
        dataType: 'json',
        data: restaurant,
        success: function (response) {
            swal({
                title: "Saved!",
                text: "That data has been inserted!",
                type: "success"
            },
            function () {
                window.location.href = '/Restaurants/Index/';
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
            url: "http://localhost:17940/api/Restaurants/" + Id,
            type: "DELETE",
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                function () {
                    window.location.href = '/Restaurants/Index/';
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
        url: 'http://localhost:17940/api/Restaurants/' + Id,
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            $('#Id').val(result.Id);
            $('#Name').val(result.Name);
            $('#Description').val(result.Description);
            $('#Cinemas').val(result.Cinemas_Id);

            $('#myModal').modal('show');
            $('#Save').hide();
            $('#Update').show();
        }
    })
}

function Edit() {
    var restaurant = new Object();
    restaurant.Id = $('#Id').val();
    restaurant.Name = $('#Name').val();
    restaurant.Description = $('#Description').val();
    restaurant.Cinemas_Id = $('#Cinemas').val();
    $.ajax({
        url: 'http://localhost:17940/api/Restaurants/' + restaurant.Id,
        type: 'PUT',
        data: restaurant,
        dataType: 'json',
        success: function (response) {
            swal({
                title: "Updated!",
                text: "your data has been updated!",
                type: "success"
            },
            function () {
                window.location.href = '/Restaurants/Index/';
                $('#Id').val('');
                $('#Name').val('');
                $('#Description').val('');
            });
        },
        error: function (response) {
            swal("Oops", "We couldn't connect to the server!", "error");
        }
    });
}

function validateInsertRestaurant() {
    var allValid = true;
    if ($('#Name').val() == "" || $('#Name').val() == " ") {
        allValid = false;
        $('#Name').siblings('span.error').css('visibility', 'visible');
    }
    if ($('#Description').val() == "" || $('#Description').val() == " ") {
        allValid = false;
        $('#Description').siblings('span.error').css('visibility', 'visible');
    }
    if ($('#Cinemas').val() == 0 || $('#Cinemas').val() == "0") {
        allValid = false;
        $('#Cinemas').siblings('span.error').css('visibility', 'visible');
    }

    if (allValid == true) {
        Save();
    }
}

function validateEditRestaurant() {
    var allValid = true;
    if ($('#Name').val() == "" || $('#Name').val() == " ") {
        allValid = false;
        $('#Name').siblings('span.error').css('visibility', 'visible');
    }
    if ($('#Description').val() == "" || $('#Description').val() == " ") {
        allValid = false;
        $('#Description').siblings('span.error').css('visibility', 'visible');
    }
    if ($('#Cinemas').val() == 0 || $('#Cinemas').val() == "0") {
        allValid = false;
        $('#Cinemas').siblings('span.error').css('visibility', 'visible');
    }

    if (allValid == true) {
        Edit();
    }
}

function hiddenRestaurantAlert() {
    $('#Name').siblings('span.error').css('visibility', 'hidden');
    $('#Description').siblings('span.error').css('visibility', 'hidden');
    $('#Cinemas').siblings('span.error').css('visibility', 'hidden');
}

function clearRestaurantScreen() {
    $('#Id').val('');
    $('#Name').val('');
    $('#Description').val('');
    $('#Cinemas').val(0);
    hiddenRestaurantAlert();
}