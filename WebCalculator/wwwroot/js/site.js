
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
        error: function (xhr, status, error) {
            console.error('Error:', error);
        }
    });
}

function OperatorStatusSwitch(operator) {
    $.ajax({
        url: 'switch',
        method: 'GET',
        data: { operator: operator },
        success: function (response) {
            ShowView();
        },
        error: function (xhr, status, error) {
            console.error('Error:', error);
        }

    })
}
