window.duplicateSection = function (sectionId) {
    const container = document.getElementById(sectionId);
    const template = container.querySelector(".template-container");

    if (!container || !template) {
        console.warn("Template not found for:", sectionId);
        return;
    }

    const clone = template.cloneNode(true);

    const inputs = clone.querySelectorAll("input, textarea, select");
    inputs.forEach(el => {
        if (el.tagName === "SELECT") el.selectedIndex = 0;
        else el.value = "";
    });

    container.appendChild(clone);
};

document.addEventListener("DOMContentLoaded", function () {
    const accordionContainer = document.getElementById("accordionPanelsStayOpenExample");

    if (accordionContainer && typeof Sortable !== "undefined") {
        new Sortable(accordionContainer, {
            handle: ".accordion-header",
            animation: 150,
            ghostClass: "sortable-ghost"
        });
    }
});

window.autoGrow = function (element) {
    element.style.height = "auto";
    element.style.height = element.scrollHeight + "px";
};
