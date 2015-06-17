﻿CREATE TABLE [StoredGrant] (
    [Id] [int] NOT NULL IDENTITY,
    [GrantId] [nvarchar](4000) NOT NULL,
    [GrantType] [int] NOT NULL,
    [Subject] [nvarchar](4000) NOT NULL,
    [Scopes] [nvarchar](4000) NOT NULL,
    [ClientId] [nvarchar](4000) NOT NULL,
    [Created] [datetime] NOT NULL,
    [Expiration] [datetime] NOT NULL,
    [RefreshTokenExpiration] [datetime],
    [RedirectUri] [nvarchar](4000),
    CONSTRAINT [PK_dbo.StoredGrant] PRIMARY KEY ([Id])
)
INSERT INTO [__MigrationHistory] ([MigrationId], [Model], [ProductVersion]) VALUES ('201307221743397_StoredGrants', 0x1F8B0800000000000400ED5DCB72E3B815DDA72AFFA0D27E2CB7DD8B644A9E298F1FDD4EC6ED2ED33DBDA64948669A0F0D4176DBDF96453E29BF1090144580BC201E044C4AF14E22C0732F818B8BE7C5F9EFBFFFB3FCF5390A67DF518A83243E9BBF3B3A9ECF50EC257E10AFCFE679B6FAE96FF35F7FF9EB5F96577EF43CFBA3CE775AE4236FC6F86CFE94659B9F170BEC3DA1C8C54751E0A5094E56D99197440BD74F1627C7C77F5FBC7BB74004624EB066B3E57D1E674184CA3FE4EF45127B6893E56E789BF828C4DBE724C52951679FDC08E18DEBA1B3F9C353107FCB9097E5293ABAF11101CA5E1C94926F38BA479B0407599206081F397F86F3D97918B844470785ABF96CF3FEE72F1839599AC46B67E366811B3EBC6C10495FB92146DB2FFA79F35EF6A38E4F8A8F5AB8719C64042E89B50A65BEFB5CF2C157E5F7146A951F7D36FF10268F6E484A6815ACF3B49242BD405EF9277A611E90479FD36483D2ECE51EADB63037FE7CB660DF5BB45FDCBD46BD5368427EC5D9E9C97CF6290F43F73144BB022325EA90E2461F508C886EC8FFEC66194AE3E2DDAA663A525B329C2043C5AF5A12A91D627AF3D975F08CFCDF51BCCE9E76D26EDDE7FAC9FBE36362815FE280982A792B4B7304A8D72FFA06E31CA55FD26034D9A45633D7CBAE2237084750E212ADDC3CCCBE3A0FC9371417E2C753E22369301350A354E1F760850AF724B2FE7E44A26010E591414407271749F22D4066E0EED19F7990A2ABD84B5F3695F7AAE07E4B9210B9B12EE03D0A5F48B57D764B07B40E70B6755B03E1AFE222F3451810CF72419E07ABC0233EE73CCF9E0A5FE31912B24A520F917E22C51FD224DFDCA2E891FC7E0A3643A10B13FF9CA4D9B05A2B50B02ACC72D1F42BBDBDCD57E71AF9A8AAAF83ED732A43F2CDD8A369F32B3237756006EF633AF863CFC330F941C657E1CB4362CC4F94685F838C0CE9EE911B4686801D1C5E27A996B2D20D85D8F12D31BE3438E8B1D93A268E9CF2B5E6476AD57F51DF5CF750A3AB72EF9C6F4B8554D0EB8B775EA2081169DEEB29A1D0753CA439CE0EB63518ED356E11C6EE1A39C8CBD352B611D0A2EA8B19B45958EB232EAACB43BE0DF04B14A2B5069EB4ED371DF62DCA5CDFCDDCB766A055907745F59FBC159E54BB4C624CC49A01BB4738C9C9C4E7EE07F9B66B32D633037B136DC2C00B32738817C4BFA9A3491BE0B9BFC2A4FED1FA6D0E245327C53C3926BF58AF6D08DC71A3D00AF03F7E6456703FBB183F3CA5390B5EAE000D9E7F7521CDAC021535F809A8417F93048D7379BD216ED3958EA783A5956179D10F4F79F4B84947F9F8663D901AF24D6696E104A44741C522D89B6BD62AC0CBC05DC709260D1D1F7809D283F272B6F590BA5E69BD560AB6334DC28754A4753731C2D68C2D6728B92F84BD3460B647AC49976FC3CD7CF6CDC44CD432B3FA7C08D635A087A5B6EF82C3F261231997A1C9C55836BA9B6B3C18D87166B6645E7F4CCB6C6628AA417EEEDFEA3D5014CF59EA5EBA99FB6E44D92723CA3E9D8CA7ADFD16D1F47B40C6AA5ABEF652C3D75E1EACAFBD0CF026745FC61AA9526797348FF83C253F6EE28FA9EF90219E676207843ED131F68ACA98CB1AD5F4AC31FDD796EC202F45237C77B5A352BB985E0B95EB496D2E4E5445F536E69CEEC4424AFAB6ADF9A3891EABB1DD233F4889DF1E65E9787B446B9522FC6466CFA10034B983B7D5D0F04E63896A795BB080AFCAF4807C53F151A375C4C2EF1B63B1486A16E725A64FA8CB881D3EB62CE6EF4EE646BB83CC6436B49DD49B6924A539FA1F52F7B0BAF0F28346E9CC4AC9062615F9E3BF48A734C207946D05FF9F8D4052549899622383162C36017B085C1B8A1E14C8C14E6CB0D3EF82CA30AA8034EFD6BA4A1515C8EC721659D173DB3D5D6DB36775BB0362EE668D06553CE111986BD18F4CCFC601487EF8850898384A0C00728FA98B152D4FF3823A02E77C4570DD039200B2E814A5484835D50580A1538522B0D6413000B5F7A89808BE39C70020F30E398840A9BD7D0095BBF32F820576B6BBE8502691BAD4B1DCAEB654A200A7B563D5C56A6710E0B5D76521C8CEDAAD5C21F24B4E0C504F41408CDDFC446878CD200D02A2C770A00BDE39DB5DDA725145696F1F2C179C70EEE5ADBBD9906AA0C2BBB74F664E15DB7DF193A31E411D55180B0F0381D43B6D7792C8F7B96BD44AAD4AF73A4871566C113CBA458775E1479D6CFA5D4BAD00BF87698F909BBAA9DF2D7ED76722E4A3E0C18EAA25ACA98B6B523C11C12B4B0AEDD49752B9C4713C377453609C7E91847914F3C6FA7D6F3741E23446F3541E893AD9C7A8D33C56C56263B8BBA06CBA3C3A149C4DA343E9CAE8ADA86B00BF95435942EBA42A20A195435E021C604D4B807328D85D37E09A31C06EB23C36107D4D6303C9CAD8FC406C40123FB3BC5CC978215ABAE42B2A3AF40470B3927B32CACB6BA2BA69F0E6A91A1286A1300F6BB968B9ED7627B2E8F422AD1596760725D57D31D3186BFD9664307A2954D47B2960D9E9C3761B675DEBD7C01137A9212DA81D83DE45A7535591CB68F42E64F9581E8B0D48A7E1D8140DAFD90D4B07FD65379BB2AC56A43A20A69563321EA05C6FB0D6F2E5A2EB4B99A2862F0F656BEC0A07D1B32359388FCA688B1B22CF0EB9B8D9146C978D81678C964D522825E8681C53445086C9B4867AB5CC6257280AAE2FE5897B4119987DE8003B01F45DD44E166519DD787A404A37D3BE0D987BE3EFB97D7F37ABAA4C7A89AF2B86BF0058E28ED3D081756C6B6D5EE9528152B4A8F92B234EC3138C54D7DBED046BF52BBCEB40AA4EA550A6518F022F585F670078BB3A491513386BD4450732A9CA610F497545B0E9EA25539F6D828AA64E9B4CBB69EF9C596B40F277359472452D490D6EDA4D4A702F038D2EC8AA3086E75FD7C08CE4F9D9E465F16F70A045F173C94BEABDD38116D69B51615DA3EFA2076699A32FA39AA57C02AABF8E14689B4A5F5E79A9504C022D094A1F7397878E5CE842D2A92A6D1DBC68816DF96096C9B87AEA1483352F2F75E3432952E4E0A591A6E1DB47AA53FA1089B54A95BB8542AA56E5A16C562BFFB289BEC5F376DEC91881E8320B93B62096256105322076EABF39890E75952A48BC4E46AF7B614280D845602A613216C7BBD3C2A8D7E1CA90F1333D2F4FDDB2C06D2CC52DAB3DB3A7BE6B2C4CDA54BF1C09BB1201D8B1ADAE5DA9DA94A9A9AA09DB6CDD51C1384F3649452F705756795B9973F70434CC6F6579FDED33EE37509746308A53CF35D04E3868275A68A71CB4D30979A5EED1626B8EA9FF76895296C8358921B8CEE9B2E59C3AD754F4BD3DDC3931F740309D159DA0E0603AE72355CF4342373B302D14489747876F79A0F1E11C535807696E66A0119BA7AA4875F07717AD4E9147846E4FA071A1F4835B11A843172CCF00B5677DFB3366D21D430B9A8E0F361DA56F33DF7498F040760C4525281FF8A3AF37004EFDD1C98AD8FC4D3C205959EFDE8D485E1E4529F046612B693A6EA50968B2E759E07B1B4A2142E7C27FD78E7FA9EE6360DA5EF9640C7F606EED617B5F0233D6A91EBDE6F08BBAFC8081691E4FA65D30117AF6B6557897359462845B297D6FDB691DBB6B186888DD43459CAE41518F156CBBBE5981B1EEFAA1621BC14023E904ABF6A1181C0DD477183040F54395B97973D9003B376F9EAB8C28E06B0CD8C1059CC7FEB8C5AAB7E844DFB6B3ECA46F9FECFEEFA26FB791AF6286E54E286C95653EABA739C57212CE50745464289CC9361A161DBD2F78A1EB6CB76E1CAC10AE02FCCEE6651AC3C7ACC195BCC0D80FF78030B99C020BEF9D51BD4DA5C5951C7F7753EFC94D81BB358652219B8686988ECDC9E013191B9701F2141B9702F2BB943665908458078F4B41AC03C625207E0CB4C144E4C33AD04A34787A0284A4C33AB06DC2619D3AEAD00D8B41F6916CD88ABF6EDD95AA6F7A262DAD1DBD39148BE216D60181788507357F1EA7F00050904F588CB7875CC296862D7D34C2527DA7119660639240126063E83D2C019A32F68CC277DABE98C3DC3B0090C7DA3BD1A14A6F08E050E02E53AF413F3B3996DE6958FA7E91F34EA3CCB82D8FE5E4D507E2DE92AD0F09DDE43DE44BD90BB70DDAD9B43878A76A7052D4BB3AC042DA5D1D5011E5AE0EA604DDAED694444CB5AB33939623DA35368CE4B3BE1813A1B76A38842EC698805E925BDBC3ECC970D84EC3B5ED2175ADC58213B1D61A2CCF2930D65A29C9363984B9F5794D97A4CBD9A30BBE174CB27B56F5CC6AE2F8B5BEC70CAF562ADE4EA51B18A55AB21B9096556F178E59D7363EC4023957ABABB2475F1905B4EED0A39A873EB1077DFA5A3E647CEED23DF222002BA94147401D44D0DAD2E7528EEA78BB3EBAD1FD991EB6C9420D03B3F484C6C0F9549F2DBBD020FA343EED781B76BCCE54806BDCBE2D644BD60DD04D19C3E652676A1F6930B5D8DE4F99A98D6871F57E44AA4C2B2D9C66C934DDC1F8433A6EADA9AE32C3A531D4A1E3940E7DA54FEA373B14FA4A2BA6DB62AE34E7E83BC4945A034F9696D29C762CEBE45E749C2C67A4A46543F3C036B9A336543F672404FBBA9DB81A256497DE8B5573177A511BB83E0364152D418AE8B15853A9D41F4A152952A4272FA4CE209A490E9F6447277E5648A5A14495E21282B2C1856384DF52A490F00D4837330C9922D5C05C903A06783545BAF46787943244CB29528C9B13D2C900A1A7481F7E5648A1D7E70285B4B0C9190A7EB5454E5148DE40DE5129DA5148AE2639690F3729BFF6C4D80D356917BE490325E8B09A8A484DC1F66980F5B41B5FB95CDCE771314AAAFE5D221CAC1B8825C18CAB05D706B4CE7313AF927AE844BE92D6A8CED21A59D51DC279D1985C2F23C91EC2B83C39F0871BE6C5E8307A44FE4D7C97679B3C3BC718458F21730DD872D12FBFA47665755EDE95AB54D8C42710358362607917FF9607A1BFD3FB1A98D471200A8BD94EA088564E11FC85D62F3BA44F492C09B42DBE4BB44171D19A1E10F1E08587BA8B1DF73BE2EB262E43B6C496852B4EDD086F319AF7C95F627E7EF4FCCBFF00C8F4861FA9B50000, '5.0.0.net45')
