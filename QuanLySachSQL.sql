--Tạo database
Create database QuanLySach
On Primary
(
	Name = QuanLySach_Data,
	Filename = 'F:\QuanLyBanSach\QuanLySach_Dat.mdf',
	Size = 10MB,
	Maxsize = 50MB
)
Log On
(
	Name = QuanLySach_Log,
	Filename = 'F:\QuanLyBanSach\QuanLySach_Log.ldf',
	Size = 5MB,
	Maxsize = 25MB
)
--Tạo cấu trúc của database
USE QuanLySach
--Tạo bảng Người Dùng
Create table NguoiDung
(
	TaiKhoan nvarchar(50) primary key,
	MatKhau nvarchar(50)
)
--Tạo bảng tác giả
Create table TACGIA
(
	MaTG char(10)primary key,
	TenTG nvarchar(50),
	DiaChiTG nvarchar(50),
	SDT char(15)
)
--Tạo bảng Thể loại
Create table TheLoai
(
	MaTL char(10) primary key,
	TenTheLoai nvarchar(50)
)
--Tạo bảng NXB
Create table NXB
(
	MaNXB char(10) primary key,
	TenNXB nvarchar(50),
	DiaChiNXB nvarchar(50),
	SDTNXB char(15)
)
--Tạo bảng	Sách
Create table SACH
(
	MaS char(10) primary key,
	TenS nvarchar(50),
	MaTL char(10),
	SLuong int,
	NgayNhap date,
	MaTG char(10),
	MaNXB char(10),
	Gia float,
	Foreign Key (MaTL) references TheLoai(MaTL),
	Foreign Key (MaTG) references TACGIA(MaTG),
	Foreign Key (MaNXB) references NXB(MaNXB)
)
--Tạo bảng Khách Hàng
Create table KHACHHANG
(
	MaKH char(10) primary key,
	TenKH nvarchar(30),
	DiaChi nvarchar(50),
	SDT char(15)
)
--Tạo bảng Hóa Đơn
Create table HOADON
(
	MaHD char(10)primary key,
	TenHD nvarchar(50),
	MaKH char(10),
	NgayHD date,
	TongTien float,
	Foreign Key (MaKH) references KHACHHANG(MaKH)
)
--Tạo bảng CT Hóa Đơn
Create table CTHOADON
(
	MaCTHD char(10),
	MaHD char(10),
	MaS char(10),
	SoLuong int,
	DonGia float,
	primary key (MaCTHD,MaHD),
	Foreign Key (MaHD) references HOADON(MaHD),
	Foreign Key (MaS) references SACH(MaS)
)
--Tạo các thành phần của database
--Tạo trigger kiểm tra thêm mới tài khoản người dùng
Create trigger insert_trig_nguoidung
on NguoiDung
for insert
as	
if ((select TaiKhoan from inserted) is not null)
begin
	print N'Tạo tài khoản thành công'
end
--Tạo trigger kiểm tra việc thay đổi mật khẩu người dùng
Create trigger update_trig_nguoidung
on NguoiDung
for update
as
if update (TaiKhoan)
	begin
		print N'Không thể thay đổi tài khoản'
		rollback transaction
	end
else
	print N'Bạn đã cập nhật thành công mật khẩu'
--drop trigger update_trig_nguoidung
--tạo trigger xóa tài khoản
Create trigger delete_trig_nguoidung
on NguoiDung
for delete
as
	print N'Bạn đã xóa thành công tài khoản'
--Tạo proc thêm NXB
CREATE Proc ThemNXB
	@MaNXB char(10),
	@TenNXB nvarchar(50),
	@DiaChiNXB nvarchar(50),
	@SDTNXB char(15)
 AS
 BEGIN
	 if( exists (select MaNXB from SACH where MaNXB=@MaNXB))
		begin
			PRINT N'Đã tồn tại mã sách này'
			rollback transaction
		end
	 ElSE
		INSERT INTO NXB(MaNXB,TenNXB,DiaChiNXB,SDTNXB)
		values(@MaNXB,@TenNXB,@DiaChiNXB,@SDTNXB)	
 END
 --Tạo proc chỉnh sửa nxb
 Create proc SuaNXB
	@MaNXB char(10),
	@TenNXB nvarchar(50),
	@DiaChiNXB nvarchar(50),
	@SDTNXB char(15)
as
begin
if( exists (select MaNXB from NXB where MaNXB=@MaNXB))
	begin	
		UPDATE NXB SET MaNXB= @MaNXB,TenNXB=@TenNXB,DiaChiNXB=@DiaChiNXB,SDTNXB=@SDTNXB  
		WHERE MaNXB=@MaNXB
	end
ElSE
	begin
		PRINT N'Đã tồn tại mã tồn tại mã NXB này'
		rollback transaction
	end
END
--Tạo trigger xóa NXB
create trigger delete_trig_nxb
on NXB
for delete
as
	print N'Xóa nhà xuất bản thành công'
--tạo trigger xóa nxb thì các dòng tương ứng ở Sach sẽ bị xóa
 create trigger delete_trig_snxb
 on NXB
 for delete
 as 
 begin
	delete from SACH
	where MaNXB=(select MaNXB from deleted)
	print N'Xóa thành công'
 end
--Tạo proc thêm tác giả
Create proc ThemTacGia
	@MaTG char(10),
	@TenTG nvarchar(50),
	@DiaChiTG nvarchar(50),
	@SDT char(15)
As
Begin
	if (exists (select MaTG from TACGIA where MaTG=@MaTG))
		begin
			print N'Đã tồn tại mã tác giả này'
			rollback transaction
		end
	else
		begin
			insert into TACGIA(MaTG,TenTG,DiaChiTG,SDT)
			values (@MaTG,@TenTG,@DiaChiTG,@SDT)
		end
end
--Tạo proc sửa tác giả
Create proc SuaTacGia
	@MaTG char(10),
	@TenTG nvarchar(50),
	@DiaChiTG nvarchar(50),
	@SDT char(15)
As
Begin
	if (exists (select MaTG from TACGIA where MaTG=@MaTG))
		begin
			update	TACGIA
			SET MaTG=@MaTG,TenTG=@TenTG,DiaChiTG=@DiaChiTG,SDT=@SDT
		end
	else
		print N'Không tồn tại mã tác giả này'
end
--tạo trigger thông báo việc xóa tác giả
create trigger delete_trig_tacgia
on TACGIA
for delete
as 
	print N'Xóa tác giả thành công'
--Tạo trigger xóa tác giả thì toàn bộ dòng tương ứng ở bảng sách sẽ bị xóa
create trigger delete_trig_stg
on TACGIA
for delete
as
begin
	delete from SACH
	where MaTG = (select MaTG from deleted)
	print N'Xóa thành công'
end
--Tạo trigger thông báo việc thêm thể loại
create trigger insert_trig_theloai
on TheLoai
for insert
as
	print N'Thêm thể loại thành công'
--Tạo trigger thông báo việc sửa thể loại
create trigger update_trig_theloai
on TheLoai
for update
as
	print N'Thay đổi mã thể loại thành công'
--tạo trigger thông báo việc xóa thể loại
create trigger delete_trig_theloai
on TheLoai
for delete
as
	print N'Xóa thể loại thành công'
--Tạo trigger xóa thể loại thì các dòng tương ứng bên bảng sách sẽ bị xóa
create trigger delete_trig_xtl
on  TheLoai
for delete
as
begin
	delete from TheLoai
	where MaTL = (select MaTL from deleted)
	print N'Xóa thành công'
end 
--Tạo proc thêm sách
CREATE Proc ThemSach
 @MaS char(10),
 @TenS Nchar(50),
 @MaTL char(10),
 @SLuong int,
 @NgayNhap date,
 @MaTG char(10),
 @MaNXB char(10),
 @Gia float
 AS
 BEGIN
	 if( exists (select MaS from SACH where MaS=@MaS))
		begin
			PRINT N'Đã tồn tại mã sách này'
			rollback transaction
		end
	 ElSE
		INSERT INTO SACH (MaS,TenS,MaTL,SLuong,NgayNhap,MaTG,MaNXB,Gia)
		values(@MaS,@TenS,@MaTL,@SLuong,@NgayNhap,@MaTG,@MaNXB,@Gia)	
 END
GO
--drop proc ThemSach
--Sửa sách 
CREATE Proc SuaSach
 @MaS char(10),
 @TenS Nvarchar(50),
 @MaTL char(10),
 @SLuong int,
 @NgayNhap date,
 @MaTG char(10),
 @MaNXB char(10),
 @Gia float
 AS
 BEGIN
	 if( exists (select MaS from SACH where MaS=@MaS))
		UPDATE SACH SET TenS =@TenS ,MaTL=@MaTL , SLuong=@SLuong ,NgayNhap =@NgayNhap ,MaTG =@MaTG ,MaNXB=@MaNXB ,Gia=@Gia WHERE MaS=@MaS
	 ElSE
		PRINT N'Không tồn tại mã tồn tại mã sách này'
		rollback transaction
 END
 --drop proc SuaSach
-- Load danh sách tất cả sách
 Create Proc TatCaSach
 as
 begin
	select * from Sach
 end
-- Tìm kiếm sách theo mã sách là @MaS
 create Proc TimTheoMaSach
 @MaS char(10)
 As
 BEGIN
	if(not exists( select * from SACH where MaS=@MaS))
		print N'Không tồn tại mă sách này'
	else
		select * from SACH where MaS=@MaS
 END
 -- Tìm kiếm sách theo mã thể loại
 create Proc TimTheoTheLoai
 @MaTL char(10)
 as
 begin
	if(not exists( select * from SACH where MaTL=@MaTL))
		print N'Không tồn tại mă thể loại này'
	select * from SACH where SACH.MaTL=@MaTL
 end
 -- Tìm kiếm sách theo mã tác giả
 create Proc TimTheoTacGia
 @MaTG char(10)
 As
 BEGIN
	if(not exists( select * from SACH where MaTG=@MaTG))
		print N'Không tồn tại mă tác giả này'
	else
		select * from SACH where MaTG=@MaTG
 END
 --Tìm kiếm theo nhà xuất bản
 create Proc TimTheoNXB
 @MaNXB char(10)
 As
 BEGIN
	if(not exists( select * from SACH where MaNXB=@MaNXB))
		print N'Không tồn tại mă nhà xuất bản này'
	else
		select * from SACH where MaNXB=@MaNXB
 END
 -- Bán n cuốn sách của sách có mã là @MaS
 Create Proc BanSach
 @MaS char(10),
 @n int
 AS
 Begin
	if exists(select * from SACH where MaS=@MaS and SLuong=@n and @n>=0)
	begin
		update SACH set SLuong=Sluong-@n where MaS=@MaS
	end
	else
	begin
		return
	end
 End
GO
--Lấy sách vào quấy sách
Create Proc LaySachVaoQuay
 as
 begin
	select s.MaS , s.TenS ,tl.TenTheLoai, s.SLuong , tg.TenTG ,n.TenNXB ,s.Gia 
	from Sach as s ,TheLoai as tl ,TacGia as tg ,NXB as n 
	WHERE s.MaTL = tl.MaTL and s.MaTG = tg.MaTG and s.MaNXB = n.MaNXB
 end
-- Kiểm tra số sách đã bán trong ngày với tên sách được truyền vào
create function slSach_daban(@TenS nvarchar(50))
returns int
as
begin
	declare @slSach int;
	select @slSach = (select SoLuong from CTHOADON,SACH,HOADON
	where (CTHOADON.MaHD = HOADON.MaHD)
	and (CTHOADON.MaS = SACH.MaS)
	and TenS = @TenS
	and HOADON.NgayHD=GETDATE())
	return @slSach
end
 --Hàm trả về số lượng sách còn trong kho sách theo tên sách
 create function slSach_conlai(@TenS nvarchar(50))
 returns int
 as
 begin
	declare @slSachcl int;
	select @slSachcl = (select SLuong from SACH
	where TenS = @TenS)
	return @slSachcl
end
--Xóa sách theo mã sách
Create Proc XoaSach
 @MaS char(10)
 AS
 BEGIN
  if(not exists( select*from SACH where MaS=@MaS))
	print N'Không tồn tại mă sách này'
  else
	delete from SACH where MaS=@MaS
END
--Tạo view hiển thị thông tin sách
create view vwttsach(MaS,TenS,TenTG,TenNXB,TenTheLoai)
as
	select SACH.MaS,TenS,TACGIA.TenTG,NXB.TenNXB,TheLoai.TenTheLoai
	from SACH,TACGIA,NXB,TheLoai
	where SACH.MaTG = TACGIA.MaTG
	and SACH.MaNXB = NXB.MaNXB
	and SACH.MaTL = TheLoai.MaTL
 --tạo proc thêm khách hàng
 Create Proc ThemKhachHang
 @MaKH char(10),
 @TenKh Nvarchar(30),
 @DiaChi nvarchar(50),
 @SDT char(15)
 AS
 BEGIN
	 if( exists (select MaKH from KHACHHANG where MaKH=@MaKH))
		PRINT N'Đã tồn tại mã khách hàng này'
	 ElSE
		INSERT INTO KHACHHANG (MaKH,TenKh,DiaChi,SDT)
		values(@MaKH,@TenKh,@DiaChi,@SDT)	
 END
GO
--Tạo proc sửa khách hàng
create proc SuaKhachHang
@MaKH char(10),
@TenKH nvarchar(30),
@DiaChi nvarchar(50),
@SDT char(15)
as
begin
	if( exists (select MaKH from KHACHHANG where MaKH=@MaKH))
		update KHACHHANG
		SET MaKH=@MaKH,TenKH=@TenKH,DiaChi=@DiaChi,SDT=@SDT
	else
		print N'Không tồn tại mã khách hàng này'
end 
--Xóa khách hàng theo mã khách
Create Proc XoaKhachHang
 @MaKH char(10)
 AS
 BEGIN
  if(not exists( select*from KHACHHANG where MaKH=@MaKH))
	print N'Không tồn tại mă khách hàng này'
  else
	delete from KHACHHANG where MaKH=@MaKH
 END
 --Tạo proc lấy tất cả khách hàng
 Create proc LayTatCaKhachHang
 as
	select * from KHACHHANG
 --Tạo view lấy tất cả khách hàng
 Create view vwLayTatCaKhachHang
 as
	select * from KHACHHANG
--Tạo proc tìm kiếm khách hàng với mã khách hàng được truyền vào
create proc TKKhach
@MaKH char(10)
as
begin
if(not exists(select * from KHACHHANG where MaKH=@MaKH))
	print N'Không tồn tại mã khách hàng này này'
else
	select * from KHACHHANG where MaKH=@MaKH
end
--Tạo proc thêm hóa đơn
create proc ThemHoaDon
@MaHD char (10),
@TenHD nvarchar(50),
@MaKH char (10),
@NgayHD date,
@TongTien float
as
	begin
	 if( exists (select MaHD from HOADON where MaHD=@MaHD))
		PRINT N'Đã tồn tại mã hóa đơn này'
	 ElSE
		INSERT INTO HOADON (MaHD,TenHD,MaKH,NgayHD,TongTien)
		values(@MaKH,@TenHD,@MaKH,@NgayHD,@TongTien)	
 END		
--Tạo proc sửa hóa đơn
create proc SuaHoaDon
@MaHD char (10),
@TenHD nvarchar(50),
@MaKH char (10),
@NgayHD date,
@TongTien float
as
	begin
	 if( exists (select MaHD from HOADON where MaHD=@MaHD))
		update HOADON
		SET MaHD=@MaHD,TenHD=@TenHD,@MaKH=@MaKH,NgayHD=@NgayHD,TongTien=@TongTien
	else
		print N' Không tồn tại mã hóa đơn này'
	end
--Tạo trigger xóa hóa đơn
create trigger del_trig_hoadon
on HOADON
for delete
as
	print N'Xóa thành công' 
 --Tạo proc LayDSHoaDon
 CREATE Proc LayDSHoaDon
 as
 begin
	 select MaHD,TenHD,MaKH,NgayHD,TongTien from HoaDon
 end
--Tạo trigger xóa Hóa đơn thì các cột tương ứng bên bảng CTHD sẽ bị xóa
create trigger delete_trig_xhd
on HOADON
for delete
as
begin
	delete from CTHOADON
	where MaHD = (select MaHD from deleted)
	print N'Xóa thành công'
end
--Tạo proc kiểm tra việc thêm CT hóa đơn
Create proc ThemCTHD
@MaCTHD char(10),
 @MaHD char(10),
 @MaS char(10),
 @SoLuong int,
 @DonGia float
 AS
 BEGIN
 if( exists (select MaHD from CTHoaDon where MaHD=@MaHD))
	BEGIN
	if ( exists (select MaCTHD from CTHOADON where MaCTHD = @MaCTHD))
		begin
		print N'Đã tồn tại mã CTHD'
		rollback transaction
		end
	 else 
		insert into CTHOADON (MaCTHD,MaHD,MaS,SoLuong,DonGia)
		values (@MaCTHD,@MaHD,@MaS,@SoLuong,@DonGia)
	END
else
	begin
	print N'Không tồn tại mã hóa đơn'
	rollback transaction
	end
END
 --Tạo proc sửa CTHOADON
 CREATE proc SuaCTHoaDon
 @MaCTHD char(10),
 @MaHD char(10),
 @MaS char(10),
 @SoLuong int,
 @DonGia float
 AS
 BEGIN
	 if( exists (select MaHD from CTHoaDon where MaHD=@MaHD))
		UPDATE CTHOADON SET MaHD=@MaHD, MaS =@MaS ,SoLuong=@SoLuong , DonGia=@DonGia WHERE MaCTHD =@MaCTHD
	 ElSE
		PRINT N'Không tồn tại mã hóa đơn này'
 END
 --Tạo trigger thông báo việc xóa CTHD
 create trigger del_trig_CTHD
 on CTHOADON
 for delete
 as
	print N'Xóa thành công'
--Tạo trigger tự động tính trường DonGia của bảng CTHD bằng giá sách+10%
create trigger DonGia
on CTHOADON
for insert as
begin
	update CTHOADON
	set DonGia=Gia+Gia*0.1
	from SACH,CTHOADON,(select MaCTHD,MaS from inserted) as I
	where SACH.MaS=CTHOADON.MaS
	and I.MaCTHD=CTHOADON.MaCTHD
	and I.MaS=CTHOADON.MaS
end
 --Tạo proc lấy DS chi tiết hóa đơn
 CREATE Proc DanhSachCTHoaDon
 as
 begin
	 select *,(SoLuong*DonGia) as Thanh_Tien from CTHOADON
 end
 --Tạo view hiển thị danh sách sách và khách hàng đã mua sách
 create view vwttmb(TenS,TenKH,SDT,NgayMua,SoLuong)
 as
	select SACH.TenS,KHACHHANG.TenKH,SDT,HOADON.NgayHD,CTHOADON.SoLuong
	from KHACHHANG,SACH,HOADON,CTHOADON
	where SACH.MaS=CTHOADON.MaS
	and CTHOADON.MaHD=HOADON.MaHD
	and HOADON.MaKH=KHACHHANG.MaKH
 --Tạo view hiển thị danh sách sách và khách hàng mua trong ngày
create view vwSachduocmua(TenKH,SDT,TenS,SL)
as
	select KHACHHANG.TenKH,SDT,SACH.TenS,CTHOADON.SoLuong
	from KHACHHANG,SACH,CTHOADON,HOADON
	where KHACHHANG.MaKH = HOADON.MaKH
	and SACH.MaS=CTHOADON.MaS
	and HOADON.MaHD=CTHOADON.MaHD
	and HOADON.NgayHD = GETDATE()
--Tạo view hiển thị chi tiết đơn hàng
create view vw_chitietdonhang(MaHD,TenHD,NgayHD,TenKH,TenS,SoLuong,ThanhTien)
as
	select HOADON.MaHD,TenHD,NgayHD,KHACHHANG.TenKH,SACH.TenS,CTHOADON.SoLuong,(SoLuong*DonGia) as ThanhTien
	from HOADON,CTHOADON,KHACHHANG,SACH
	where HOADON.MaHD=CTHOADON.MaCTHD
	and HOADON.MaKH=KHACHHANG.MaKH
	and CTHOADON.MaS = SACH.MaS
--Tạo trigger tính tổng tiền
create trigger TinhTongTien
on HOADON
for insert as
if ((select MaHD from inserted) is not null)
begin
	update HOADON
	set TongTien = TongTien + 
	( Select (SoLuong*DonGia) as ThanhTien
	from CTHOADON, (select MaHD from inserted) as I
	where CTHOADON.MaHD=I.MaHD
	and I.MaHD=HOADON.MaHD)
end
--tạo trigger cập nhật lại số sách sau khi bán hoặc cập nhật
create trigger trig_capnhatsach
on CTHOADON
after insert as
begin
	update SACH set SLuong = SLuong -(select SoLuong from inserted where MaS=SACH.MaS)
	from SACH
	Join inserted on SACH.MaS = inserted.MaS
end
go
--tạo trigger  cập nhật số lượng sách sau khi cập nhật chi tiết hóa đơn
create trigger trig_capnhathd
on CTHOADON
after update as
begin
	update SACH set SLuong = SLuong -
	(select SoLuong from inserted where MaS = SACH.MaS)+
	(select SoLuong from deleted where MaS = SACH.MaS)
	from SACH
	join deleted on SACH.MaS=deleted.MaS
end
go
--tạo trigger cập nhật lại sách khi hủy ct hóa đơn
create trigger trig_huycthd
on CTHOADON
for delete as
begin
	update SACH
	SET SLuong = SLuong + (Select SLuong from deleted where MaS = SACH.MaS)
	from SACH
	join deleted on SACH.MaS = deleted.MaS
end
go