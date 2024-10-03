$(document).ready(function () {
    ShowView();
});

function ShowView() {
    $.ajax({
        url: 'listOperation',
        method: 'GET',
        success: function (data) {
            $('#listOperation').html(data);

            $('.operator').on('click', function () {
                OperatorStatusSwitch($(this).data('operator'));
            });
        },
        error: function (error) {
            console.error('Error:', error);
        }
    });
}

function OperatorStatusSwitch(operator) {
    $.ajax({
        url: 'switch',
        method: 'GET',
        data: { operatorType: operator },
        success: function (response) {
            ShowView();
        },
        error: function (error) {
            console.error('Error:', error);
        }

    })
}
