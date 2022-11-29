namespace ServiceNotification
{
    partial class ServicePrueba
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
            this.Pendientes = new System.Timers.Timer();
            ((System.ComponentModel.ISupportInitialize)(this.Pendientes)).BeginInit();
            // 
            // Pendientes
            // 
            this.Pendientes.Enabled = true;
            this.Pendientes.Interval = 10000D;
            this.Pendientes.Elapsed += new System.Timers.ElapsedEventHandler(this.timer1_Elapsed);
            // 
            // ServicePrueba
            // 
            this.ServiceName = "ServicePrueba";
            ((System.ComponentModel.ISupportInitialize)(this.Pendientes)).EndInit();

        }

        #endregion

        private System.Timers.Timer Pendientes;
    }
}
