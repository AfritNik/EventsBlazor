using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Components;

namespace NI.Helpers.Blazor.Modal
{
    public class ModalService: IModalService
    {
        public event Action<ModalResult> OnClose;
        public event Action CloseModal;
        public event Action<string, RenderFragment, ModalParameters, ModalOptions> OnShow;
        private Type m_modalType;

        public void Cancel()
        {
            CloseModal?.Invoke();
            OnClose?.Invoke(ModalResult.Cancel());
        }

        public void Show<T>(string title, ModalParameters parameters) where T : ComponentBase
        {
            Show<T>(title, parameters, new ModalOptions());
        }

        public void Show<T>(string title, ModalParameters parameters = null, ModalOptions options = null) where T : ComponentBase
        {
            Show(typeof(T), title, parameters, options);
        }

        public void Show(Type contentComponent, string title, ModalParameters parameters, ModalOptions options)
        {
            if (!typeof(ComponentBase).IsAssignableFrom(contentComponent))
                throw new ArgumentException("Must be a blazor component");

            var content = new RenderFragment(x=>
            {
                x.OpenComponent(1, contentComponent);
                x.CloseComponent();
            });

            m_modalType = contentComponent;
            OnShow?.Invoke(title, content, parameters, options);
        }

        public void Close(ModalResult modalResult)
        {
            modalResult.ModalType = m_modalType;
            CloseModal?.Invoke();
            OnClose?.Invoke(modalResult);
        }

        
    }
}
