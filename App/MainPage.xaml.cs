using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.UI.Popups;
using System.Collections.ObjectModel;

// Il modello di elemento per la pagina vuota è documentato all'indirizzo http://go.microsoft.com/fwlink/?LinkId=391641

namespace App
{
    /// <summary>
    /// Pagina vuota che può essere utilizzata autonomamente oppure esplorata all'interno di un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Richiamato quando la pagina sta per essere visualizzata in un Frame.
        /// </summary>
        /// <param name="e">Dati dell'evento in cui vengono descritte le modalità con cui la pagina è stata raggiunta.
        /// Questo parametro viene in genere utilizzato per configurare la pagina.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: preparare la pagina da visualizzare qui.

            // TODO: se l'applicazione contiene più pagine, assicurarsi che si stia
            // gestendo il pulsante Indietro dell'hardware effettuando la registrazione per
            // l'evento Windows.Phone.UI.Input.HardwareButtons.BackPressed.
            // Se si utilizza l'elemento NavigationHelper fornito da alcuni modelli,
            // questo evento viene gestito automaticamente.
        }

        private async void RegistraTask_Click(object sender, RoutedEventArgs e)
        {
            String nomeMioTask = "FirstTask";

            //Controllo se il task è stato gia registrato
            foreach (var taskCorrente in BackgroundTaskRegistration.AllTasks)
            {
                if (taskCorrente.Value.Name == nomeMioTask)
                {  
                    //Avverto l'utente che il task è gia stato registrato
                    await (new MessageDialog("Task già registrato")).ShowAsync();
                    return;
                }
            }

            //Metodo da invocare per utilizzare gli eventi (triggers)
            await BackgroundExecutionManager.RequestAccessAsync();

            //creo il task che eseguirà il codice implementato nel metodo Run()
            BackgroundTaskBuilder taskBuilder = new BackgroundTaskBuilder { Name = "First Task", TaskEntryPoint = "MyTask.FirstTask" };
            //imposto l'evento che azionerà il task, in questo caso avverrà dopo 15 minuti circa
            taskBuilder.SetTrigger(new TimeTrigger(15, true));
            //registro un nuovo task
            BackgroundTaskRegistration registroTask = taskBuilder.Register();
            await (new MessageDialog("Task registrato")).ShowAsync();
        }
    }
}
