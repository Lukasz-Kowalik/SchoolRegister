//subject filter
$('#subjects-filter-input').change(() => {
    const filterValue = $('#subjects-filter-input').val();
    $.get('/Subject/Index',
        $.param({ filterValue: filterValue }),
        (resultData) => {
            $('.subjects-table-data').html(resultData);
        });
});
//student filter
$('#students-filter-input').change(() => {
    const studentsFilterValue = $('#students-filter-input').val();
    $.get('/Student/Index',
        $.param({ studentsFilterValue: studentsFilterValue }),
        (resultData) => {
            $('.students-table-data').html(resultData);
        });
});