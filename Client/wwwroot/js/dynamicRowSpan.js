﻿(function() {
    window.dynamicRowSpan = {
        initialize: function () {
            resizeAllGridItems();
            window.addEventListener("resize", resizeAllGridItems);
        }
    };

    // source: https://css-tricks.com/piecing-together-approaches-for-a-css-masonry-layout/
    function resizeGridItem(item) {
        const grid = document.getElementsByClassName("cocktails-grid")[0];
        const rowHeight = parseInt(window.getComputedStyle(grid).getPropertyValue('grid-auto-rows'));
        const rowGap = parseInt(window.getComputedStyle(grid).getPropertyValue('grid-row-gap'));
        const rowSpan =
            Math.ceil((item.querySelector('.cocktail-card-content').getBoundingClientRect().height + rowGap) /
                (rowHeight + rowGap));
        item.style.gridRowEnd = "span " + rowSpan;
    }

    function resizeAllGridItems() {
        const allItems = document.getElementsByClassName("cocktail-card");
        for (let x = 0; x < allItems.length; x++) {
            resizeGridItem(allItems[x]);
        }
    }
})();