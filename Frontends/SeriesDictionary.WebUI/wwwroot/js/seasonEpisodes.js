$(document).ready(function () {
    var episodesData = @Html.Raw(JsonConvert.SerializeObject(Model.Seasons, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
    var episodesDict = {};
    episodesData.forEach(function (season) {
        episodesDict[season.SeasonNumber] = season.Episodes;
    });

    $('#seasonSelect').change(function () {
        var seasonNumber = $(this).val();
        $('#episodeList').empty();

        if (seasonNumber && episodesDict[seasonNumber]) {
            var episodeHtml = '<h3 class="text-secondary">Bölümler</h3>';
            episodeHtml += '<div class="row">';

            episodesDict[seasonNumber].forEach(function (episode) {
                episodeHtml += '<div class="col-md-4 mb-3">';
                episodeHtml += '<div class="card">';
                episodeHtml += '<div class="card-body">';
                episodeHtml += '<h5 class="card-title">Bölüm ' + episode.EpisodeNumber + '</h5>';
                episodeHtml += '<p class="card-text">Bölüm ID: ' + episode.Id + '</p>';
                episodeHtml += '</div>';
                episodeHtml += '</div>';
                episodeHtml += '</div>';
            });

            episodeHtml += '</div>';
            $('#episodeList').html(episodeHtml);
        }
    });
});
