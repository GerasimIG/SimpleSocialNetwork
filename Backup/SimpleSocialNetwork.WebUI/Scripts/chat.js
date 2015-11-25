
       $(function () {

           var chatHub = $.connection.chatHub;

           registerClientMethods(chatHub);

           $.connection.hub.start().done(function () {

               registerEvents(chatHub)

               var name = $("#FirstName").val();
               var toDbUserId = $("#PhoneNumber").val();

               if (name.length > 0) {
                   chatHub.server.connect(name, toDbUserId);
               }
           });
       });


function registerEvents(chatHub) {
    $('#btnSendMsg').click(function () {

        var msg = $("#txtMessage").val();
        if (msg.length > 0) {

            var userName = $('#hdUserName').val();
            var toUserId = $("#PhoneNumber").val()
            chatHub.server.sendPrivateMessage(toUserId, msg);
            $("#txtMessage").val('');
        }
    });

    $("#txtMessage").keypress(function (e) {
        if (e.which == 13) {
            $('#btnSendMsg').click();
        }
    });


}
function registerClientMethods(chatHub) {
    
    chatHub.client.onConnected = function (id, userName, allUsers, messages) {
        setScreen(true);
        $('#hdId').val(id);
        $('#hdUserName').val(userName);
        $('#spanUser').html(userName);
       
        for (i = 0; i < allUsers.length; i++) {
            AddUser(chatHub, allUsers[i].ConnectionId, allUsers[i].UserName);
        }

        for (i = 0; i < messages.length; i++) {

            AddMessage(messages[i].UserName, messages[i].Message);
        }
    }

    chatHub.client.onNewUserConnected = function (id, name) {
        AddUser(chatHub, id, name);
    }

    chatHub.client.messageReceived = function (userName, message) {
        AddMessage(userName, message);
    }


    chatHub.client.sendPrivateMessage = function (windowId, fromUserName, message) {
        AddMessage(fromUserName, message);
    }

}

function AddMessage(userName, message) {
    $('#divChatWindow').append('<div class="message"><span class="userName">' + userName + '</span>: ' + message + '</div>');

    var height = $('#divChatWindow')[0].scrollHeight;
    $('#divChatWindow').scrollTop(height);
}

function AddDivToContainer($div) {
    $('#divContainer').prepend($div);

    $div.draggable({
        handle: ".header",
        stop: function () {

        }
    });
}
