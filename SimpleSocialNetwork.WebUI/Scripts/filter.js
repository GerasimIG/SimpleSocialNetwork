$(document).ready(function () {
    $('#Country').on('change', function (e) {
        var selectedCountryName = $(this).val();
        $.getJSON('@Url.Action("GetRegions", "Search")',
            { countryName: selectedCountryName }, function (data) {
                var items;
                $.each(data, function (i, region) {
                    items += "<option>" + region + "</option>";
                });
                $('#Region').html(items);
                $('#Region').trigger('change');
            });
    });

    $('#Region').on('change', function (e) {
        var selectedRegionName = $(this).val();
        $.getJSON('@Url.Action("GetCities", "Search")',
            { regionName: selectedRegionName }, function (data) {
                var items;
                $.each(data, function (i, city) {
                    items += "<option>" + city + "</option>";
                });
                $('#City').html(items);
            });
    });
});