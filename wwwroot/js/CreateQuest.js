document.forms['QuestFormTeacher'].onsubmit = function (e) {
    e.preventDefault();
    CreateQuest();
}

function CreateQuest() {

    var name = document.getElementById('NameQuest').value;
    var correct = document.getElementById('CorrectAns').value;
    var f = document.getElementById('FirstQuest').value;
    var s = document.getElementById('SecondQuest').value;
    var t = document.getElementById('ThirdQuest').value;
    var fo = document.getElementById('FourthQuest').value;

    $.ajax({
       
        url: '../ClassRoom/CreateQuest/',
        data: {
            Name: name,
            Correct: correct,
            F : f,
            S: s,
            T: t,
            Fo : fo,
        },
        
        success: function (data) {
            document.getElementById('Acces').innerHTML = 'Вопрос добавлен!';
            $('#QuestFormTeacher').trigger('reset');
        },
        error: function (data) {
            
            alert('Ошибка');
        }
    });
}