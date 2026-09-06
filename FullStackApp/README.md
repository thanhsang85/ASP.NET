# MyApi Shop - Web API thuần (ASP.NET Core) + Frontend Bootstrap

Dự án gồm 2 phần **tách biệt hoàn toàn**:

```
FullStackApp/
 ├─ MyApi/        → ASP.NET Core Web API thuần (không MVC, không View, chỉ trả JSON)
 └─ Frontend/     → HTML + Bootstrap 5 + JavaScript (gọi API để hiển thị dữ liệu)
```

## 1. Chạy Backend (MyApi) bằng Visual Studio 2022

1. Mở Visual Studio 2022 → **File → Open → Project/Solution** → chọn `MyApi/MyApi.csproj`.
2. Đợi restore NuGet packages xong.
3. Nhấn **F5** để chạy. Trình duyệt sẽ tự mở trang **Swagger** tại:
   `https://localhost:7100/swagger`
4. Tại Swagger bạn có thể test thử tất cả API: `/api/info/home`, `/api/products`, `/api/auth/register`, `/api/auth/login`, `/api/contact`...
5. Database SQLite (`app.db`) và 4 sản phẩm mẫu được tự động tạo khi chạy lần đầu.

> Nếu Visual Studio chạy API ở cổng khác 7100 (VS tự chọn cổng ngẫu nhiên), hãy copy đúng URL đó vào bước 2 bên dưới.

## 2. Chạy Frontend (HTML/Bootstrap)

Frontend là các file tĩnh (không cần build), có 2 cách chạy:

**Cách A - Dùng Live Server (khuyên dùng):**
1. Mở thư mục `Frontend` bằng VS Code.
2. Cài extension **Live Server**.
3. Chuột phải vào `index.html` → **Open with Live Server**.

**Cách B - Mở file trực tiếp:**
- Double-click file `Frontend/index.html` để mở bằng trình duyệt (Chrome/Edge).

### Cấu hình địa chỉ API
Mở file `Frontend/js/config.js`, sửa đúng theo cổng mà `MyApi` đang chạy:
```js
const API_BASE_URL = "https://localhost:7100/api";
```

## 3. Các trang có sẵn (Frontend)
| Trang | File | Gọi API |
|---|---|---|
| Trang chủ | `index.html` | `GET /api/info/home` |
| Giới thiệu | `about.html` | `GET /api/info/about` |
| Sản phẩm | `products.html` | `GET /api/products` |
| Liên hệ | `contact.html` | `POST /api/contact` |
| Đăng ký | `register.html` | `POST /api/auth/register` |
| Đăng nhập | `login.html` | `POST /api/auth/login` |

Sau khi đăng ký/đăng nhập thành công, token JWT được lưu vào `localStorage` của trình duyệt và tự động gửi kèm cho các API cần xác thực (ví dụ: thêm/sửa/xóa sản phẩm).

## 4. Danh sách API đầy đủ

| Method | Endpoint | Cần đăng nhập? | Mô tả |
|---|---|---|---|
| GET | `/api/info/home` | Không | Nội dung trang chủ |
| GET | `/api/info/about` | Không | Nội dung trang giới thiệu |
| GET | `/api/products` | Không | Danh sách sản phẩm |
| GET | `/api/products/{id}` | Không | Chi tiết 1 sản phẩm |
| POST | `/api/products` | **Có** (Bearer token) | Thêm sản phẩm |
| PUT | `/api/products/{id}` | **Có** | Cập nhật sản phẩm |
| DELETE | `/api/products/{id}` | **Có** | Xóa sản phẩm |
| POST | `/api/contact` | Không | Gửi liên hệ |
| POST | `/api/auth/register` | Không | Đăng ký, trả về JWT token |
| POST | `/api/auth/login` | Không | Đăng nhập, trả về JWT token |

## 5. Vì sao tách API riêng và Frontend riêng?
- API (`MyApi`) chỉ làm nhiệm vụ xử lý dữ liệu, trả JSON — có thể dùng chung cho web, mobile app, hoặc frontend framework khác (React, Vue, Angular...) mà không cần sửa gì.
- Frontend (`Frontend`) chỉ là giao diện tĩnh, gọi API bằng `fetch()` — có thể thay bằng bất kỳ công nghệ frontend nào khác mà không ảnh hưởng đến backend.

## 6. Ghi chú
- Muốn đổi sang SQL Server: đổi package `Sqlite` → `SqlServer` trong `MyApi.csproj`, đổi `UseSqlite` → `UseSqlServer` trong `Program.cs`, cập nhật `ConnectionStrings` trong `appsettings.json`.
- JWT secret key nằm trong `appsettings.json` (mục `Jwt:Key`) — nên đổi thành chuỗi ngẫu nhiên dài hơn khi triển khai thực tế (production).
