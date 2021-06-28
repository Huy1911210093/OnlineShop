$(window).on('load', function() {
    "use strict";
    var preloader = $('.preloder-section');
    var searchOpen = $('#search-open');
    var headSearchClick = $('.search-click');
    var headSearchClickDismis = $('.search-close');
    var header_slider = $('#slider_one');
    var arrival_new = $('#new_arrival');
    var menuSlider = $('#menu_slider');
    var footerSlider = $('#footer_slider');
    var team_member = $('#team_slider');
    var collection_sidebar = $('#sidebar_collection');
    var blogSlider = $('#blog_slider');
    var blogPost = $('#blog_post');
    var verticalSlider = $('.vertical_slider');
    var horizontalSlider = $('#horizantal_slider_one');
    var lookbookSlider = $('#lookbook_slider');
    var latestNEWS = $('#latest_news');
    var MixItUp1 = $('#MixItUp1');
    var fancyboxImg = $('.fancybox');
    var inputCheckbox = $('input[type=checkbox]');
    var show_login = $('.showlogin');
    var showCoupon = $('.showcoupon');
    var createAccount = $('#account');
    var accountBox = $('.account-box');;
    var viewPassword = $('.view-password');
    var backLogin = $('.backto');
    var onColorClick = $('.oncolor');
    var onsizeClick = $('.onsize');
    var priceClick = $('.onprice');
    var brandClick = $('.onbrand');
    var productGrid = $('.product_grid');
    var productlist = $('.product_list');
    var womenMenu = $('.women_menu');
    var jewelleryMmenu = $('.jewellery_menu');
    var menProduct = $('.men_product');
    var menGrid = $('.men_grid');
    var womenGRID = $('.women_grid');
    var watchGRID = $('.watch_grid');
    var addPlus = $('.add');
    var removeMinus = $('.minus');
    var accordionFAQ = $("#accordion");
    var mapDiv = $('#gmap_canvas');
    var LogIN = $('.login');
    var CheckoutCoupon = $('.checkout_coupon');

    /*
    ========================================
    Preloder Setting
    ========================================
    */
    if (preloader.length) {
        preloader.fadeOut();
    }
    /*
    ==================
    Search Box pop-up
    ==================
    */
    headSearchClick.on('click', function(e) {
        e.preventDefault();
        searchOpen.addClass('searchopen');
    });
    headSearchClickDismis.on('click', function(e) {
        e.preventDefault();
        searchOpen.removeClass('searchopen');
    });
    /*
    ==================
    HEADER SLIDER
    ==================
    */
    var nextNav = '<i class="fa fa-angle-right" aria-hidden="true"></i>';
    var prevNav = '<i class="fa fa-angle-left" aria-hidden="true"></i>';
    if (header_slider.length) {
        header_slider.owlCarousel({
            loop: true,
            margin: 0,
            dots: false,
            nav: true,
            autoplay: true,
            navText: [prevNav, nextNav],
            responsive: {
                0: {
                    items: 1
                },
                600: {
                    items: 1
                },
                1000: {
                    items: 1
                }
            }
        });
    }
    /*
    ==================
    NEW ARRIVAL SLIDER
    ==================
    */
    var nextNav = '<i class="fa fa-angle-right" aria-hidden="true"></i>';
    var prevNav = '<i class="fa fa-angle-left" aria-hidden="true"></i>';
    if (arrival_new.length) {
        arrival_new.owlCarousel({
            loop: true,
            margin: 0,
            dots: false,
            nav: true,
            autoplay: false,
            navText: [prevNav, nextNav],
            responsive: {
                0: {
                    items: 1
                },
                600: {
                    items: 3
                },
                1000: {
                    items: 4
                }
            }
        });
    }
    /*
    ========================
    Sticky menu when scroll
    ========================
    */
    window.onscroll = function() { myFunction() };

    // Get the header
    var header = document.getElementById("main-menu");

    // Get the offset position of the navbar
    var sticky = header.offsetTop;

    // Add the sticky class to the header when you reach its scroll position. Remove "sticky" when you leave the scroll position
    function myFunction() {
        if (window.pageYOffset > sticky) {
            header.classList.add("sticky");
        } else {
            header.classList.remove("sticky");
        }
    }


    /*
    ========================
    Mega Menu Bag Slider
    ========================
    */
    var nextNav = '<i class="fa fa-angle-right" aria-hidden="true"></i>';
    var prevNav = '<i class="fa fa-angle-left" aria-hidden="true"></i>';
    if (menuSlider.length) {
        menuSlider.owlCarousel({
            loop: true,
            margin: 0,
            dots: false,
            nav: true,
            autoplay: true,
            navText: [prevNav, nextNav],
            responsive: {
                0: {
                    items: 1
                },
                600: {
                    items: 2
                },
                1000: {
                    items: 3
                }
            }
        });
    }
    /*
    ====================
    Footer slider
    ====================
    */
    if (footerSlider.length) {
        footerSlider.owlCarousel({
            loop: true,
            margin: 0,
            dots: false,
            autoplay: true,
            responsive: {
                0: {
                    items: 1
                },
                600: {
                    items: 3
                },
                1000: {
                    items: 10
                }
            }
        });
    }
    /*
    ====================
    Team slider
    ====================
    */
    if (team_member.length) {
        team_member.owlCarousel({
            loop: true,
            margin: 0,
            dots: false,
            autoplay: true,
            responsive: {
                0: {
                    items: 1
                },
                600: {
                    items: 3
                },
                1000: {
                    items: 5
                }
            }
        });
    }
    /*
    =========================
    Collecton Sidebar Slider
    =========================
    */
    var nextNav = '<i class="fa fa-angle-right" aria-hidden="true"></i>';
    var prevNav = '<i class="fa fa-angle-left" aria-hidden="true"></i>';
    if (collection_sidebar.length) {
        collection_sidebar.owlCarousel({
            loop: true,
            margin: 0,
            dots: false,
            nav: true,
            autoplay: false,
            navText: [prevNav, nextNav],
            responsive: {
                0: {
                    items: 1
                },
                600: {
                    items: 1
                },
                1000: {
                    items: 1
                }
            }
        });
    }

    /*
    =========================
    Blog slider
    =========================
    */
    var nextNav = '<i class="fa fa-angle-right" aria-hidden="true"></i>';
    var prevNav = '<i class="fa fa-angle-left" aria-hidden="true"></i>';
    if (blogSlider.length) {
        blogSlider.owlCarousel({
            loop: true,
            margin: 0,
            dots: false,
            nav: true,
            autoplay: false,
            navText: [prevNav, nextNav],
            responsive: {
                0: {
                    items: 1
                },
                600: {
                    items: 1
                },
                1000: {
                    items: 1
                }
            }
        });
    }
    /*
    =========================
    Blog Post Slider
    =========================
    */
    var nextNav = '<i class="fa fa-angle-right" aria-hidden="true"></i>';
    var prevNav = '<i class="fa fa-angle-left" aria-hidden="true"></i>';
    if (blogPost.length) {
        blogPost.owlCarousel({
            loop: true,
            margin: 0,
            dots: false,
            nav: true,
            autoplay: false,
            navText: [prevNav, nextNav],
            responsive: {
                0: {
                    items: 1
                },
                600: {
                    items: 1
                },
                1000: {
                    items: 2
                }
            }
        });
    }

    /*
    ========================
    PRODUCT VERTICAL SLIDER
    ========================
    */
    if (verticalSlider.length) {
        verticalSlider.bxSlider({
            mode: 'vertical',
            slideWidth: 300,
            minSlides: 3,
            slideMargin: 10,
            pager: false,
        });
    }
    /*
    ==========================
    Product Horizontal Slider
    =========================
    */
    if (horizontalSlider.length) {
        horizontalSlider.owlCarousel({
            loop: true,
            margin: 4,
            dots: false,
            nav: true,
            navText: [prevNav, nextNav],
            autoplay: true,
            responsive: {
                0: {
                    items: 3
                },
                600: {
                    items: 3
                },
                1000: {
                    items: 4
                }
            }
        });
    }
    /*
    ========================
    Lookbook Slider
    ========================
    */
    var nextNav = '<i class="fa fa-angle-right" aria-hidden="true"></i>';
    var prevNav = '<i class="fa fa-angle-left" aria-hidden="true"></i>';
    if (lookbookSlider.length) {
        lookbookSlider.owlCarousel({
            loop: true,
            margin: 0,
            dots: false,
            nav: true,
            autoplay: false,
            navText: [prevNav, nextNav],
            responsive: {
                0: {
                    items: 1
                },
                600: {
                    items: 1
                },
                1000: {
                    items: 1
                }
            }
        });
    }
    /*
    ========================
    latest-news Slider
    ========================
    */
    var nextNav = '<i class="fa fa-angle-right" aria-hidden="true"></i>';
    var prevNav = '<i class="fa fa-angle-left" aria-hidden="true"></i>';
    if (latestNEWS.length) {
        latestNEWS.owlCarousel({
            loop: true,
            margin: 0,
            dots: false,
            nav: true,
            autoplay: false,
            navText: [prevNav, nextNav],
            responsive: {
                0: {
                    items: 1
                },
                600: {
                    items: 2
                },
                1000: {
                    items: 2
                }
            }
        });
    }
    /*
    =====================
    MixItUp
    =====================
    */
    if (MixItUp1.length) {
        MixItUp1.mixItUp({
            selectors: {
                filter: '.filter-1'
            }
        });
    }

    /*
    ===================
    FANCY-BOX SECTION
    ===================
    */
    if (fancyboxImg.length) {
        fancyboxImg.fancybox();
    }

    /*
    ====================
    SHOW LOGIN
    ====================
    */
    if (show_login.length) {
        show_login.on('click', function(e) {
            e.preventDefault();
            LogIN.slideToggle("slow");
        });
    }


    /*
    ==================
    SHOW COUPON
    =================
    */
    if (showCoupon.length) {
        showCoupon.on('click', function(e) {
            e.preventDefault();
            CheckoutCoupon.slideToggle("slow");
        });
    }

    /*
    ======================
    CREATE ACCOUNT
    ======================
    */
    if (createAccount.length) {
        createAccount.on('change', function() {
            accountBox.slideToggle();
        });
    }

    /*
    =====================
    Map Section Start
    ====================
    */
    //****************************************
    // Map initialization function Calling
    //****************************************
    if (mapDiv.length) {
        initMap();
    }

    /*
    ===================
    Forgaet password
    ===================
    */
    if (viewPassword.length) {
        viewPassword.on('click', function() {
            document.getElementById('forget').style.display = 'block';
            document.getElementById('loginbox').style.display = 'none';
        });
    }
    if (backLogin.length) {
        backLogin.on('click', function() {
            document.getElementById('forget').style.display = 'none';
            document.getElementById('loginbox').style.display = 'block';
        });
    }


    /*
    =============================
    Collection sidebar hide and show
    =============================
    */

    /*color*/
    var colorList = $('.color-list');

    if (onColorClick.length) {
        onColorClick.on('click', function(e) {
            e.preventDefault();
            colorList.slideToggle("slow");
        });
    }

    /*size*/
    var sizeList = $('.size-list');
    if (onsizeClick.length) {
        onsizeClick.on('click', function(e) {
            e.preventDefault();
            sizeList.slideToggle("slow");
        });
    }

    /*price*/
    var priceList = $('.price-list');
    if (priceClick.length) {
        priceClick.on('click', function(e) {
            e.preventDefault();
            priceList.slideToggle("slow");
        });
    }

    /*brand*/
    var brandList = $('.brand-list');
    if (brandClick.length) {
        brandClick.on('click', function(e) {
            e.preventDefault();
            $('.brand-list').slideToggle("slow");
        });
    }


    /*
    ========================
    Product collection grid
    ========================
    */
    if (productGrid.length) {
        productGrid.on('click', function() {
            document.getElementById('collection_box').style.display = 'block';
            document.getElementById('collection_sidebar_list').style.display = 'none';
        });
    }
    if (productlist.length) {
        productlist.on('click', function() {
            document.getElementById('collection_box').style.display = 'none';
            document.getElementById('collection_sidebar_list').style.display = 'block';
        });
    }

    /*
    ==========================
    Jwellery Page
    ==========================
    */
    if (womenMenu.length) {
        womenMenu.on('click', function() {
            document.getElementById('women_detail').style.display = 'block';
            document.getElementById('jewellery_detail').style.display = 'none';
            document.getElementById('menProduct_detail').style.display = 'none';
        });
    }
    if (jewelleryMmenu.length) {
        jewelleryMmenu.on('click', function() {
            document.getElementById('women_detail').style.display = 'none';
            document.getElementById('menProduct_detail').style.display = 'none';
            document.getElementById('jewellery_detail').style.display = 'block';
        });
    }
    if (menProduct.length) {
        menProduct.on('click', function() {
            document.getElementById('women_detail').style.display = 'none';
            document.getElementById('jewellery_detail').style.display = 'none';
            document.getElementById('menProduct_detail').style.display = 'block';
        });
    }
    if (menGrid.length) {
        menGrid.on('click', function() {
            document.getElementById('mengrid_detail').style.display = 'block';
            document.getElementById('womenimage_detail').style.display = 'none';
            document.getElementById('watchDetail').style.display = 'none';
        });
    }
    if (womenGRID.length) {
        womenGRID.on('click', function() {
            document.getElementById('mengrid_detail').style.display = 'none';
            document.getElementById('womenimage_detail').style.display = 'block';
            document.getElementById('watchDetail').style.display = 'none';
        });
    }
    if (watchGRID.length) {
        watchGRID.on('click', function() {
            document.getElementById('mengrid_detail').style.display = 'none';
            document.getElementById('womenimage_detail').style.display = 'none';
            document.getElementById('watchDetail').style.display = 'block';

        });
    }
    /*
    ==========================
    your product title button
    ==========================
    */

    addPlus.on('click', function() {
        var $qty = $(this).closest('ul').find('.qty');
        var currentVal = parseInt($qty.val(), 10);
        if (!isNaN(currentVal)) {
            $qty.val(currentVal + 1);
        }
    });
    removeMinus.on('click', function() {
        var $qty = $(this).closest('ul').find('.qty');
        var currentVal = parseInt($qty.val(), 10);
        if (!isNaN(currentVal) && currentVal > 0) {
            $qty.val(currentVal - 1);
        }
    });
    /*
    ==================
    Accordian
    ==================
    */
    if (accordionFAQ.length) {

        accordionFAQ.accordion();
    }
    /*
    ====================
    Scroll top Section
    ====================
    */

    var scrollTop = $(".scrollTop");
    var htmlBody = $('html, body');
    var linkOne = $('.link1');
    var linkTwo = $('.link2');
    var linkThree = $('.link3');

    $(window).scroll(function() {
        var topPos = $(this).scrollTop();

        if (topPos > 100) {
            $(scrollTop).css("opacity", "1");
        } else {
            $(scrollTop).css("opacity", "0");
        }
    });

    $(scrollTop).on('click', function() {
        htmlBody.animate({
            scrollTop: 0
        }, 800);
        return false;
    });
    var h1 = $("#h1").position();
    var h2 = $("#h2").position();
    var h3 = $("#h3").position();
    linkOne.click(function() {
        htmlBody.animate({
            scrollTop: h1.top
        }, 500);
        return false;
    });
    linkTwo.click(function() {
        htmlBody.animate({
            scrollTop: h2.top
        }, 500);
        return false;
    });
    linkThree.click(function() {
        htmlBody.animate({
            scrollTop: h3.top
        }, 500);
        return false;
    });
});

//***************************************
// Contact Map function
//****************************************  
function initMap() {
    "use strict";
    var mapDiv = $('#gmap_canvas');
    if (mapDiv.length) {
        var myOptions = {
            zoom: 15,
            scrollwheel: false,
            center: new google.maps.LatLng(10.824350579307097, 106.77929396188672),
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        var map = new google.maps.Map(document.getElementById('gmap_canvas'), myOptions);
        var marker = new google.maps.Marker({
            map: map,
            position: new google.maps.LatLng(10.824350579307097, 106.77929396188672)
        });
        var infowindow = new google.maps.InfoWindow({
            content: '<strong>N30 shop</strong><br>Địa chỉ shop<br>'
        });
        google.maps.event.addListener(marker, 'click', function() {
            infowindow.open(map, marker);
        });
        infowindow.open(map, marker);
    }

}
/*
    =========================
    Pagination
    =========================
    */
;