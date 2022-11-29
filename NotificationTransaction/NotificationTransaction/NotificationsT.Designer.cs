namespace NotificationTransaction
{
    partial class NotificationsT
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.Notificar = new System.Timers.Timer();
            ((System.ComponentModel.ISupportInitialize)(this.Notificar)).BeginInit();
            // 
            // Notificar
            // 
            this.Notificar.Enabled = true;
            this.Notificar.Interval = 60000D;
            this.Notificar.Elapsed += new System.Timers.ElapsedEventHandler(this.Notificar_Elapsed);
            // 
            // NotificationsT
            // 
            this.ServiceName = "NotificationsT";
            ((System.ComponentModel.ISupportInitialize)(this.Notificar)).EndInit();

        }

        #endregion

        private System.Timers.Timer Notificar;
    }
}
