$(document).ready(function () {

    $.ajax({
        url: 'http://localhost:5114/api/user',
        type: 'GET',
        headers: {
            'Content-Type': 'application/json'
          },
        success: function (result) {
            console.log(result);
            $('tbody').empty();
            reloadUserlist(result);
            $('#UserList').DataTable()
        }
    });
});
function reloadUserlist(result) {
    var j=0;
    //Duyệt kết quả trả về
    for (let i = 0; i < result.length; i++) {
        //Tạo thông tin dòng
            if (j % 2 == 0) { var tr = '<tr class=\"trc\">'; }
            else { { var tr = '<tr class=\"trl\">'; } };
            //Thêm thông tin cột cho dòng
            console.log(result[i]);
            var td = '<td>' + result[i].ID + '</td>'
                + '<td>' + result[i].displayName + '</td>'
                + '<td>' + result[i].email + '</td> '
                + '<td>' + result[i].phone + '</td> '
                + '<td>' + result[i].dateOfBirth + '</td> '
                + '<td>' + result[i].address + '</td> ';
            //Mở rộng nội dung dòng
            tr += td + '</tr>';
            j++;
            $('tbody').append(tr);
    }

}