classDiagram
direction BT
class Actors {
   varchar(50) Name
   int State
   int AuditCreateUser
   datetime2 AuditCreateDate
   int AuditUpdateUser
   datetime2 AuditUpdateDate
   int AuditDeleteUser
   datetime2 AuditDeleteDate
   int ActorId
}
class BranchOffices {
   varchar(100) Code
   int BusinessId
   varchar(100) Name
   varchar(100) Description
   int CountryId
   varchar(max) Address
   varchar(100) Email
   varchar(100) Phone
   int State
   int BranchOfficeId
}
class Business {
   varchar(100) Code
   varchar(11) Ruc
   varchar(100) BusinessName
   varchar(max) Logo
   int CountryId
   varchar(max) Address
   varchar(100) Email
   datetime CreationDate
   varchar(100) Phone
   varchar(max) Vision
   varchar(max) Mision
   int State
   int BusinessId
}
class Categories {
   varchar(50) Name
   int State
   int AuditCreateUser
   datetime2 AuditCreateDate
   int AuditUpdateUser
   datetime2 AuditUpdateDate
   int AuditDeleteUser
   datetime2 AuditDeleteDate
   int CategoryId
}
class Clients {
   varchar(100) Name
   int DocumentTypeId
   varchar(20) DocumentNumber
   varchar(max) Address
   varchar(20) Phone
   varchar(255) Email
   int State
   int AuditCreateUser
   datetime2 AuditCreateDate
   int AuditUpdateUser
   datetime2 AuditUpdateDate
   int AuditDeleteUser
   datetime2 AuditDeleteDate
   int ClientId
}
class Country {
   int ProvinceId
   varchar(100) Name
   int State
   int CountryId
}
class Directors {
   varchar(50) Name
   int State
   int AuditCreateUser
   datetime2 AuditCreateDate
   int AuditUpdateUser
   datetime2 AuditUpdateDate
   int AuditDeleteUser
   datetime2 AuditDeleteDate
   int DirectorId
}
class MenuRoles {
   int RoleId
   int MenuId
   int State
   int MenuRolId
}
class Menus {
   varchar(150) Name
   varchar(50) Icon
   varchar(150) URL
   int FatherId
   int State
   int MenuId
}
class Movies {
   varchar(50) Title
   int IdCategory
   int IdDirector
   int Year
   int IdActor
   int Rating
   varchar(max) Description
   varchar(max) Image
   int State
   int AuditCreateUser
   datetime2 AuditCreateDate
   int AuditUpdateUser
   datetime2 AuditUpdateDate
   int AuditDeleteUser
   datetime2 AuditDeleteDate
   int MovieId
}
class Provinces {
   varchar(100) Name
   int DepartmentId
   int State
   int ProvinceId
}
class PurcharseDetails {
   int PurcharseId
   int ProductId
   int Quantity
   decimal(18,2) Price
   int AuditCreateUser
   datetime2 AuditCreateDate
   int AuditUpdateUser
   datetime2 AuditUpdateDate
   int AuditDeleteUser
   datetime2 AuditDeleteDate
   int PurcharseDetailId
}
class Purcharses {
   int ProviderId
   int UserId
   datetime2 PurcharseDate
   decimal(18,2) Tax
   decimal(18,2) Total
   int State
   int AuditCreateUser
   datetime2 AuditCreateDate
   int AuditUpdateUser
   datetime2 AuditUpdateDate
   int AuditDeleteUser
   datetime2 AuditDeleteDate
   int PurcharseId
}
class Roles {
   varchar(50) Description
   int State
   int RoleId
}
class SaleDetails {
   int SaleId
   int ProductId
   int Quantity
   decimal(18,2) Price
   decimal(18,2) Discount
   int AuditCreateUser
   datetime2 AuditCreateDate
   int AuditUpdateUser
   datetime2 AuditUpdateDate
   int AuditDeleteUser
   datetime2 AuditDeleteDate
   int SaleDetailId
}
class Sales {
   int ClientId
   int UserId
   datetime2 SaleDate
   decimal(18,2) Tax
   decimal(18,2) Total
   int State
   int AuditCreateUser
   datetime2 AuditCreateDate
   int AuditUpdateUser
   datetime2 AuditUpdateDate
   int AuditDeleteUser
   datetime2 AuditDeleteDate
   int SaleId
}
class UserRoles {
   int RoleId
   int UserId
   int State
   int BranchOfficeId
   int UserRoleId
}
class Users {
   varchar(50) UserName
   varchar(max) Password
   varchar(max) Email
   varchar(max) Image
   int State
   int AuditCreateUser
   datetime2 AuditCreateDate
   int AuditUpdateUser
   datetime2 AuditUpdateDate
   int AuditDeleteUser
   datetime2 AuditDeleteDate
   int UserId
}
class sysdiagrams {
   sysname name
   int principal_id
   int version
   varbinary(max) definition
   int diagram_id
}

BranchOffices  -->  Business : BusinessId
BranchOffices  -->  Country : CountryId
Business  -->  Country : CountryId
Country  -->  Provinces : ProvinceId
MenuRoles  -->  Menus : MenuId
MenuRoles  -->  Roles : RoleId
Movies  -->  Actors : IdActor:ActorId
Movies  -->  Categories : IdCategory:CategoryId
Movies  -->  Directors : IdDirector:DirectorId
PurcharseDetails  -->  Purcharses : PurcharseId
Purcharses  -->  Users : UserId
SaleDetails  -->  Sales : SaleId
Sales  -->  Clients : ClientId
Sales  -->  Users : UserId
UserRoles  -->  BranchOffices : BranchOfficeId
UserRoles  -->  Roles : RoleId
UserRoles  -->  Users : UserId
