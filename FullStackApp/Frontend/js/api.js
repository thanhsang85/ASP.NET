// ===== Quản lý token đăng nhập (lưu trong localStorage) =====
const Auth = {
  getToken: () => localStorage.getItem("token"),
  getUser: () => JSON.parse(localStorage.getItem("user") || "null"),
  setSession: (token, user) => {
    localStorage.setItem("token", token);
    localStorage.setItem("user", JSON.stringify(user));
  },
  clearSession: () => {
    localStorage.removeItem("token");
    localStorage.removeItem("user");
  },
  isLoggedIn: () => !!localStorage.getItem("token"),
};

// ===== Hàm gọi API dùng chung =====
async function apiFetch(path, options = {}) {
  const headers = { "Content-Type": "application/json", ...(options.headers || {}) };
  const token = Auth.getToken();
  if (token) headers["Authorization"] = `Bearer ${token}`;

  const res = await fetch(`${API_BASE_URL}${path}`, { ...options, headers });

  let data = null;
  try { data = await res.json(); } catch (_) { /* không có body JSON */ }

  if (!res.ok) {
    const message = data?.message || data?.errors?.join(", ") || `Lỗi ${res.status}`;
    throw new Error(message);
  }
  return data;
}

// ===== Render thanh điều hướng dùng chung cho mọi trang =====
function renderNavbar(activePage) {
  const user = Auth.getUser();
  const loggedIn = Auth.isLoggedIn();

  const navHtml = `
  <nav class="navbar navbar-expand-lg navbar-dark bg-dark shadow-sm">
    <div class="container">
      <a class="navbar-brand fw-bold" href="index.html">MyApi Shop</a>
      <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navMenu">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navMenu">
        <ul class="navbar-nav me-auto">
          <li class="nav-item"><a class="nav-link ${activePage==='home'?'active':''}" href="index.html">Trang chủ</a></li>
          <li class="nav-item"><a class="nav-link ${activePage==='about'?'active':''}" href="about.html">Giới thiệu</a></li>
          <li class="nav-item"><a class="nav-link ${activePage==='products'?'active':''}" href="products.html">Sản phẩm</a></li>
          <li class="nav-item"><a class="nav-link ${activePage==='contact'?'active':''}" href="contact.html">Liên hệ</a></li>
        </ul>
        <ul class="navbar-nav">
          ${loggedIn ? `
            <li class="nav-item d-flex align-items-center text-light me-3">Xin chào, ${user?.fullName || user?.email}</li>
            <li class="nav-item"><button id="logoutBtn" class="btn btn-outline-light btn-sm">Đăng xuất</button></li>
          ` : `
            <li class="nav-item"><a class="nav-link ${activePage==='login'?'active':''}" href="login.html">Đăng nhập</a></li>
            <li class="nav-item"><a class="btn btn-primary btn-sm ms-2 ${activePage==='register'?'active':''}" href="register.html">Đăng ký</a></li>
          `}
        </ul>
      </div>
    </div>
  </nav>`;

  document.getElementById("navbar-placeholder").innerHTML = navHtml;

  const logoutBtn = document.getElementById("logoutBtn");
  if (logoutBtn) {
    logoutBtn.addEventListener("click", () => {
      Auth.clearSession();
      window.location.href = "index.html";
    });
  }
}

function showAlert(containerId, message, type = "danger") {
  const container = document.getElementById(containerId);
  if (!container) return;
  container.innerHTML = `<div class="alert alert-${type}" role="alert">${message}</div>`;
}
