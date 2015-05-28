CREATE TABLE [AssessmentModule].[CinaScale] (
    [CinaScaleKey]                            BIGINT         NOT NULL,
    [Version]                                 INT            NOT NULL,
    [IsVisited]                               BIT            NOT NULL,
    [ExperiencedNauseaOrVomitedRecentlyValue] BIGINT         NULL,
    [ExperiencedNauseaOrVomitedRecentlyMin]   BIGINT         NULL,
    [ExperiencedNauseaOrVomitedRecentlyMax]   BIGINT         NULL,
    [FeelsHotOrColdCode]                      NVARCHAR (200) NULL,
    [FeelsHotOrColdName]                      NVARCHAR (200) NULL,
    [FeelsHotOrColdValue]                     INT            NULL,
    [FeelsHotOrColdIsDefault]                 BIT            NULL,
    [FeelsHotOrColdSortOrder]                 INT            NULL,
    [HasAbdominalPainCode]                    NVARCHAR (200) NULL,
    [HasAbdominalPainName]                    NVARCHAR (200) NULL,
    [HasAbdominalPainValue]                   INT            NULL,
    [HasAbdominalPainIsDefault]               BIT            NULL,
    [HasAbdominalPainSortOrder]               INT            NULL,
    [HasMuscleAchesCode]                      NVARCHAR (200) NULL,
    [HasMuscleAchesName]                      NVARCHAR (200) NULL,
    [HasMuscleAchesValue]                     INT            NULL,
    [HasMuscleAchesIsDefault]                 BIT            NULL,
    [HasMuscleAchesSortOrder]                 INT            NULL,
    [ObservedGooseFleshCode]                  NVARCHAR (200) NULL,
    [ObservedGooseFleshName]                  NVARCHAR (200) NULL,
    [ObservedGooseFleshValue]                 INT            NULL,
    [ObservedGooseFleshIsDefault]             BIT            NULL,
    [ObservedGooseFleshSortOrder]             INT            NULL,
    [ObservedLacriminationCode]               NVARCHAR (200) NULL,
    [ObservedLacriminationName]               NVARCHAR (200) NULL,
    [ObservedLacriminationValue]              INT            NULL,
    [ObservedLacriminationIsDefault]          BIT            NULL,
    [ObservedLacriminationSortOrder]          INT            NULL,
    [ObservedNasalCongestionCode]             NVARCHAR (200) NULL,
    [ObservedNasalCongestionName]             NVARCHAR (200) NULL,
    [ObservedNasalCongestionValue]            INT            NULL,
    [ObservedNasalCongestionIsDefault]        BIT            NULL,
    [ObservedNasalCongestionSortOrder]        INT            NULL,
    [ObservedRestlessnessCode]                NVARCHAR (200) NULL,
    [ObservedRestlessnessName]                NVARCHAR (200) NULL,
    [ObservedRestlessnessValue]               INT            NULL,
    [ObservedRestlessnessIsDefault]           BIT            NULL,
    [ObservedRestlessnessSortOrder]           INT            NULL,
    [ObservedSweatingCode]                    NVARCHAR (200) NULL,
    [ObservedSweatingName]                    NVARCHAR (200) NULL,
    [ObservedSweatingValue]                   INT            NULL,
    [ObservedSweatingIsDefault]               BIT            NULL,
    [ObservedSweatingSortOrder]               INT            NULL,
    [ObservedTremorCode]                      NVARCHAR (200) NULL,
    [ObservedTremorName]                      NVARCHAR (200) NULL,
    [ObservedTremorValue]                     INT            NULL,
    [ObservedTremorIsDefault]                 BIT            NULL,
    [ObservedTremorSortOrder]                 INT            NULL,
    [ObservedYawningCode]                     NVARCHAR (200) NULL,
    [ObservedYawningName]                     NVARCHAR (200) NULL,
    [ObservedYawningValue]                    INT            NULL,
    [ObservedYawningIsDefault]                BIT            NULL,
    [ObservedYawningSortOrder]                INT            NULL,
    PRIMARY KEY CLUSTERED ([CinaScaleKey] ASC)
);


















GO


