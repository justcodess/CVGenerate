// Accordion sırasını kaydet
function saveOrder() {
    const items = document.querySelectorAll("#accordionPanelsStayOpenExample .accordion-item");
    const order = Array.from(items).map(item => item.dataset.sectionId);
    localStorage.setItem("accordionOrder", JSON.stringify(order));
}

// Accordion sırasını yükle
function loadOrder() {
    const container = document.getElementById("accordionPanelsStayOpenExample");
    const order = JSON.parse(localStorage.getItem("accordionOrder"));
    if (!order) return;

    order.forEach(id => {
        const item = container.querySelector(`[data-section-id="${id}"]`);
        if (item) container.appendChild(item);
    });
}

// Yeni section ekleme
window.duplicateSection = function (sectionId) {
    const container = document.getElementById(sectionId);
    const template = container.querySelector(".template-container");
    if (!container || !template) return;

    const clone = template.cloneNode(true);

    // İçerikleri sıfırla
    const inputs = clone.querySelectorAll("input, textarea, select");
    inputs.forEach(el => {
        if (el.tagName === "SELECT") el.selectedIndex = 0;
        else el.value = "";
    });

    container.appendChild(clone);
    bindButtons(); // Yeni gelen butonlara olayları bağla
};

// Textarea otomatik boyutlandırma
window.autoGrow = function (element) {
    element.style.height = "auto";
    element.style.height = element.scrollHeight + "px";
};

// Butonlar: Temizle ve Sil
function bindButtons() {
    // Temizle butonları
    document.querySelectorAll(".clear-section").forEach(btn => {
        btn.onclick = function () {
            const container = this.closest(".template-container");
            if (!container) return;

            container.querySelectorAll("input, textarea, select").forEach(el => {
                if (el.tagName === "SELECT") el.selectedIndex = 0;
                else el.value = "";
            });
        };
    });

    // Sil butonları
    document.querySelectorAll(".delete-section").forEach(btn => {
        btn.onclick = function () {
            const container = this.closest(".template-container");
            if (!container) return;

            const parent = container.parentElement;
            const total = parent.querySelectorAll(".template-container").length;

            if (total <= 1) {
                alert("Bu alan zorunludur ve silinemez.");
                return;
            }

            container.remove();
        };
    });
}


// Sayfa yüklendiğinde çalıştır
document.addEventListener("DOMContentLoaded", function () {
    const accordionContainer = document.getElementById("accordionPanelsStayOpenExample");

    if (accordionContainer && typeof Sortable !== "undefined") {
        new Sortable(accordionContainer, {
            handle: ".accordion-header",
            animation: 150,
            ghostClass: "sortable-ghost",
            onEnd: saveOrder
        });

        loadOrder();
    }

    bindButtons(); // Başlangıçta butonları bağla
});

// Form submit engelle
document.addEventListener("submit", function (e) {
    e.preventDefault();
});
