$(document).ready(function () {
    LoadIndexFilm();
    LoadCategoryCombo();
    hiddenFilmAlert();
    $('#table').DataTable({
        "ajax": LoadIndexFilm()
    });
});

function LoadIndexFilm() {
    $.ajax({
        url: 'http://localhost:17940/api/Films',
        type: 'GET',
        async: false,
        dataType: 'json',
        success: function (film) {
            var html = '';
            var i = 1;
            $.each(film, function (index, val) {
                html += '<tr>';
                html += '<td>' + i + '</td>';
                html += '<td>' + val.Title + '</td>';
                html += '<td>' + val.Rating + '</td>';
                html += '<td>' + val.Poster + '</td>';
                html += '<td>' + val.Synopsis + '</td>';
                html += '<td>' + val.Description + '</td>';
                html += '<td>' + val.Duration + '</td>';
                html += '<td>' + val.Status + '</td>';
                html += '<td>' + val.Categories.Name + '</td>';
                html += '<td> <a href="#" onclick="return GetById(' + val.Id + ');">Edit</a> ';
                html += '| <a href="#" onclick="return Delete(' + val.Id + ')">Delete</a></td>';
                html += '</tr>';
                i++;
            });
            $('.tbody').html(html);
        }
    });
}

function LoadCategoryCombo() {
    $.ajax({
        url: 'http://localhost:17940/api/Categories',
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            var category = $('#Categories');
            category.empty();
            category.append($('<option/>').val('0').text('Select'));
            $.each(result, function (i, Category) {
                $("<option></option>").val(Category.Id).text(Category.Name).appendTo(category);
            });
        }
    });
}

function Save() {
    var film = new Object();
    film.Title = $('#Title').val();
    film.Rating = $('#Rating').val();
    film.Poster = $('#Poster').val();
    film.Synopsis = $('#Synopsis').val();
    film.Description = $('#Description').val();
    film.Duration = $('#Duration').val();
    film.Status = $('#Status').val();
    film.Categories_Id = $('#Categories').val();
    $.ajax({
        url: 'http://localhost:17940/api/Films',
        type: 'POST',
        dataType: 'json',
        data: film,
        success: function (response) {
            swal({
                title: "Saved!",
                text: "That data has been inserted!",
                type: "success"
            },
            function () {
                window.location.href = '/Films/Index/';
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
            url: "http://localhost:17940/api/Films/" + Id,
            type: "DELETE",
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                function () {
                    window.location.href = '/Films/Index/';
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
        url: 'http://localhost:17940/api/Films/' + Id,
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            $('#Id').val(result.Id);
            $('#Title').val(result.Title);
            $('#Rating').val(result.Rating)
            $('#Poster').val(result.Poster)
            $('#Synopsis').val(result.Synopsis)
            $('#Description').val(result.Description)
            $('#Duration').val(result.Duration)
            $('#Status').val(result.Status)
            $('#Categories').val(result.Categories_Id);

            $('#myModal').modal('show');
            $('#Save').hide();
            $('#Update').show();
        }
    })
}

function Edit() {
    var film = new Object();
    film.Id = $('#Id').val();
    film.Title = $('#Title').val();
    film.Rating = $('#Rating').val();
    film.Poster = $('#Poster').val();
    film.Synopsis = $('#Synopsis').val();
    film.Description = $('#Description').val();
    film.Duration = $('#Duration').val();
    film.Status = $('#Status').val();
    film.Categories_Id = $('#Categories').val();
    $.ajax({
        url: 'http://localhost:17940/api/Films/' + film.Id,
        type: 'PUT',
        data: film,
        dataType: 'json',
        success: function (response) {
            swal({
                title: "Updated!",
                text: "your data has been updated!",
                type: "success"
            },
            function () {
                window.location.href = '/Films/Index/';
                $('#Id').val('');
                $('#Name').val('');
            });
        },
        error: function (response) {
            swal("Oops", "We couldn't connect to the server!", "error");
        }
    });
}

function validateInsertFilm() {
    var allValid = true;
    if ($('#Title').val() == "" || $('#Title').val() == " ") {
        allValid = false;
        $('#Title').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Title').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Rating').val() == "" || $('#Rating').val() == " ") {
        allValid = false;
        $('#Rating').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Rating').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Poster').val() == "" || $('#Poster').val() == " ") {
        allValid = false;
        $('#Poster').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Poster').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Synopsis').val() == "" || $('#Synopsis').val() == " ") {
        allValid = false;
        $('#Synopsis').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Synopsis').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Description').val() == "" || $('#Description').val() == " ") {
        allValid = false;
        $('#Description').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Description').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Duration').val() == "" || $('#Duration').val() == " " || $('#Duration').val() < 0) {
        allValid = false;
        $('#Duration').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Duration').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Status').val() == "" || $('#Status').val() == " ") {
        allValid = false;
        $('#Status').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Status').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Categories').val() == 0 || $('#Categories').val() == "0") {
        allValid = false;
        $('#Categories').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Categories').siblings('span.error').css('visibility', 'hidden');
    }

    if (allValid == true) {
        Save();
    }
}

function validateEditFilm() {
    var allValid = true;
    if ($('#Title').val() == "" || $('#Title').val() == " ") {
        allValid = false;
        $('#Title').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Title').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Rating').val() == "" || $('#Rating').val() == " ") {
        allValid = false;
        $('#Rating').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Rating').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Poster').val() == "" || $('#Poster').val() == " ") {
        allValid = false;
        $('#Poster').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Poster').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Synopsis').val() == "" || $('#Synopsis').val() == " ") {
        allValid = false;
        $('#Synopsis').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Synopsis').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Description').val() == "" || $('#Description').val() == " ") {
        allValid = false;
        $('#Description').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Description').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Duration').val() == "" || $('#Duration').val() == " " || $('#Duration').val() < 0) {
        allValid = false;
        $('#Duration').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Duration').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Status').val() == "" || $('#Status').val() == " ") {
        allValid = false;
        $('#Status').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Status').siblings('span.error').css('visibility', 'hidden');
    }
    if ($('#Categories').val() == 0 || $('#Categories').val() == "0") {
        allValid = false;
        $('#Categories').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Categories').siblings('span.error').css('visibility', 'hidden');
    }

    if (allValid == true) {
        Edit();
    }
}

function hiddenFilmAlert() {
    $('#Title').siblings('span.error').css('visibility', 'hidden');
    $('#Rating').siblings('span.error').css('visibility', 'hidden');
    $('#Poster').siblings('span.error').css('visibility', 'hidden');
    $('#Synopsis').siblings('span.error').css('visibility', 'hidden');
    $('#Description').siblings('span.error').css('visibility', 'hidden');
    $('#Duration').siblings('span.error').css('visibility', 'hidden');
    $('#Status').siblings('span.error').css('visibility', 'hidden');
    $('#Categories').siblings('span.error').css('visibility', 'hidden');


}

function clearFilmscreen() {
    $('#Id').val('');
    $('#Title').val('');
    $('#Rating').val('');
    $('#Poster').val('');
    $('#Synopsis').val('');
    $('#Description').val('');
    $('#Duration').val('');
    $('#Status').val('');
    $('#Categories').val(0);
    hiddenFilmAlert();
}