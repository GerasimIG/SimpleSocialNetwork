$(document).ready(function () {
    $('#postForm').submit(function (event) {

        var msg = $("#message").val();
        if (msg.length === 0) return false;

        event.preventDefault();
        var data = $(this).serialize();
        var url = $(this).attr('action');

        $.post(url, data, function (response) {
            $('#posts').html(response);
        });

        $("#message").val('');
    });

    $(document).on('submit', '.removePost', function () {

        event.preventDefault();
        var data = $(this).serialize();
        var url = $(this).attr('action');

        var form = this;
        $.post(url, data, function (response) {
            $(form).parents('#posts').html(response);
        });
    })

    // може виникнути помилка через парент
    $(document).on('submit', '.commentForm', function () {

        var msg = $(this).find("#commentMessage").val();
        if (msg.length === 0) return false;

        event.preventDefault();
        var data = $(this).serialize();
        var url = $(this).attr('action');


        var form = this;
        $.post(url, data, function (response) {
           var newComments = $(form).parents('.comments').html(response);
            newComments.find("#commentMessage").val('');
        });
    })
    
    $(document).on('click', '.commentsLink', function (event) {
        event.preventDefault();
        var url = $(this).attr('href');
        //може бути баг при зміні верстки
        $(this).parents('li').find('.comments').load(url);
        $(this).hide();
        $(this).next().show();
    });

    $(document).on('click', '.hideCommentsLink', function (event) {
        //може бути баг при зміні верстки
        $(this).parents('li').find('.comments').html('');
        $(this).hide();
        $(this).prev().show();
        return false;
    });

    /// може виникнути помилка через парент
    $(document).on('submit', '.removeComment', function () {
        event.preventDefault();
        var data = $(this).serialize();
        var url = $(this).attr('action');

        var form = this;
        $.post(url, data, function (response) {
            $(form).parents('.comments').html(response);
        });
    })
});