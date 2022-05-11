/*
Author URI: http://webthemez.com/
Note: 
Licence under Creative Commons Attribution 3.0 
Do not remove the back-link in this web template 
-------------------------------------------------------*/

$(window).load(function () {
    jQuery('#all').click();
    return false;
});

$(document).ready(function () {
    $('.carousel').carousel();
    $('#header_wrapper').scrollToFixed();
    $('.res-nav_click').click(function () {
        $('.main-nav').slideToggle();
        return false

    });

    GetServices();
    PopulateDropdowns();

    function resizeText() {
        var preferredWidth = 767;
        var displayWidth = window.innerWidth;
        var percentage = displayWidth / preferredWidth;
        var fontsizetitle = 25;
        var newFontSizeTitle = Math.floor(fontsizetitle * percentage);
        $(".divclass").css("font-size", newFontSizeTitle)
    }
    if ($('#main-nav ul li:first-child').hasClass('active')) {
        $('#main-nav').css('background', 'none');
    }
    $('#mainNav').onePageNav({
        currentClass: 'active',
        changeHash: false,
        scrollSpeed: 950,
        scrollThreshold: 0.2,
        filter: '',
        easing: 'swing',
        begin: function () {
        },
        end: function () {
            if (!$('#main-nav ul li:first-child').hasClass('active')) {
                $('.header').addClass('addBg');
            } else {
                $('.header').removeClass('addBg');
            }

        },
        scrollChange: function ($currentListItem) {
            if (!$('#main-nav ul li:first-child').hasClass('active')) {
                $('.header').addClass('addBg');
            } else {
                $('.header').removeClass('addBg');
            }
        }
    });

    var container = $('#portfolio_wrapper');


    container.isotope({
        animationEngine: 'best-available',
        animationOptions: {
            duration: 200,
            queue: false
        },
        layoutMode: 'fitRows'
    });

    $('#filters a').click(function () {
        $('#filters a').removeClass('active');
        $(this).addClass('active');
        var selector = $(this).attr('data-filter');
        container.isotope({
            filter: selector
        });
        setProjects();
        return false;
    });

    function splitColumns() {
        var winWidth = $(window).width(),
            columnNumb = 1;


        if (winWidth > 1024) {
            columnNumb = 4;
        } else if (winWidth > 900) {
            columnNumb = 2;
        } else if (winWidth > 479) {
            columnNumb = 2;
        } else if (winWidth < 479) {
            columnNumb = 1;
        }

        return columnNumb;
    }

    function setColumns() {
        var winWidth = $(window).width(),
            columnNumb = splitColumns(),
            postWidth = Math.floor(winWidth / columnNumb);

        container.find('.portfolio-item').each(function () {
            $(this).css({
                width: postWidth + 'px'
            });
        });
    }

    function setProjects() {
        setColumns();
        container.isotope('reLayout');
    }

    container.imagesLoaded(function () {
        setColumns();
    });


    $(window).bind('resize', function () {
        setProjects();
    });

    $(".fancybox").fancybox();
});

$('#btn-sendmessage').click(function () {
    var form = document.querySelector("#contact-form");

    if (form.reportValidity()) {
        var name = $("#sm-name").val();
        var mail = $("#sm-mail").val();
        var body = $("#sm-body").val();

        SendMail(mail, name, body);

        $("#sm-name").val("");
        $("#sm-mail").val("");
        $("#sm-body").val("");
    }
});

function GetServices() {
    $.ajax({
        url: '/Home/GetServices',
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            result.forEach(element => $("#services-ul").append('<li class="points col-md-3 services-li">' + element + '</li>'));
        }
    });
}

function SendMail(to, name, message) {
    $.ajax({
        url: '/Home/SendMail',
        type: 'POST',
        data: { to: to, subject: name, body: message },
        dataType: 'json'
    });
}

function PopulateDropdowns() {
    $.ajax({
        url: '/Home/GetPersonel',
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            result.forEach(element => $("#ddlCalisan").append('<option value="' + element.cid + '">' + element.ad + ' ' + element.soyad + '</option>'));
        }
    });

    $.ajax({
        url: '/Home/GetServicesForDropdown',
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            result.forEach(element => $("#ddlHizmet").append('<option value="' + element.hno + '">' + element.had + '</option>'));
        }
    });
}

function SaveRendesvous() {
    var form = document.querySelector("#randevu-form");

    if (form.reportValidity()) {

        var cid = $("#ddlCalisan").val();
        var hid = $("#ddlHizmet").val();
        var dateStr = $("#checkin-date").val();
        var uid = $("#userId").val();

        $.ajax({
            url: '/Home/RandevuKaydet',
            type: 'POST',
            dataType: 'json',
            data: { uid: uid, cid: cid, sid: hid, dateStr: dateStr },
            success: function (result) {
                alert("Randevunuz olusturuldu");
                window.location.href = '/Home/';
            },
            error: function () {
                alert("Hata oluþtu");
            }
        });
    }
}


wow = new WOW({
    animateClass: 'animated',
    offset: 100
});
wow.init();
document.getElementById('').onclick = function () {
    var section = document.createElement('section');
    section.className = 'wow fadeInDown';
    section.className = 'wow shake';
    section.className = 'wow zoomIn';
    section.className = 'wow lightSpeedIn';
    this.parentNode.insertBefore(section, this);
};

