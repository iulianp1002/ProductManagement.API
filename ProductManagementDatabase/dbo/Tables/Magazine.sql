CREATE TABLE [dbo].[Magazine] (
    [CodMagazin] NVARCHAR (20)  NOT NULL,
    [Denumire]   NVARCHAR (150) NULL,
    [Detalii]    NVARCHAR (250) NULL,
    CONSTRAINT [PK_Magazine] PRIMARY KEY CLUSTERED ([CodMagazin] ASC)
);

