var points = 0;

function Quest(id) {
    var id_str = String(id);
    var select = document.getElementById(id);
    console.log(id_str);
    var selectQ = select.options[select.selectedIndex].text;
    var answer = String(selectQ);
    console.log(selectQ);
    $.ajax({

        url: '../CheckAns/',
        data: {
            id: id,
            ans: answer,
        },
        dataType: 'json',
        success: function (data) {
            if (JSON.parse(data) === true) {
                points = points + 2;
                var text = document.getElementsByClassName(id_str);
                text.innerHTML = 'Вопрос засчитан!';
            }
        },
        error: function (data) {
            
            alert('Ошибка');
        }
    });
}
function Result() {
    if (!alert('Тестирование окончено! Ваши баллы ' + points)) { window.location.reload(); }
    
}