function get_data(expid) {
    $.ajax({
        type: "post",
        dataType: "json",
        url: `/Experiment/GetData/${expid}`,
    });

}