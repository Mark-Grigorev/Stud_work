
document.forms['LoginForm'].onsubmit = function (e) {
    e.preventDefault();
    Login();
}

function Login() {
    
    var login = document.getElementById('Login').value;
    var password = document.getElementById('Password').value;
    var ErrorBox = document.getElementById('ErrorBox');

    $.ajax({
        type: 'POST',
        url: '../Authorization/Authorization',
        data: {
            Login: login,
            Password: password
        },
        dataType: 'json',       
        success: function (data) {            
            //console.log(data);
            if (JSON.parse(data) === false) {
                ErrorBox.innerHTML = 'Неверный логин и/или пароль!';
                document.getElementById('password').value = '';
                setTimeout(function () { errorLabel.innerHTML = ''; }, 2500);
            }
            else {
                location.reload();
            }
        },
        error: function (data) {
           //console.log(data);
            alert('Ошибка');
        }
    });
}