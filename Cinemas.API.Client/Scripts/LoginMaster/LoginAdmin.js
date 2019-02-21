$(document).ready(function () {
});

function LoginAdmin(admin) {
    var admin = new Object();
    admin.username = $('#Username').val();
    admin.password = $('#Password').val();
    $.ajax({
        url: 'http://localhost:17940/api/Admins/Login',
        type: 'GET',
        dataType: 'json',
        data: admin,
        success: function (response) {
            swal({
                title: "Login Succeed!",
                text: "That data has been inserted!",
                type: "success"
            },
            function () {
                window.location.href = '/Cinemas/Index/';
            });
        },
        error: function (response) {
            swal("Oops", "We couldn't connect to the server!", "error");
        }
    });
}