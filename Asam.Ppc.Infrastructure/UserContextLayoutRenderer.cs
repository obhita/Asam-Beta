namespace Asam.Ppc.Infrastructure
{
    #region Using Statements

    using System.Text;
    using NLog;
    using NLog.LayoutRenderers;

    #endregion

    /// <summary>
    /// NLog Renderer for User Context
    /// </summary>
    [LayoutRenderer ( "user-context" )]
    public class UserContextLayoutRenderer : LayoutRenderer
    {
        #region Constructors and Destructors

        public UserContextLayoutRenderer ()
        {
            Separator = ":";
        }

        #endregion

        #region Public Properties

        public string Separator { get; set; }

        #endregion

        #region Methods

        protected override void Append ( StringBuilder builder, LogEventInfo logEvent )
        {
            builder.Append ( string.Format ( "User: {0}", string.Join ( Separator, UserContext.SystemAccountKey, UserContext.UserName, UserContext.UserId ) ) );
        }

        #endregion
    }
}