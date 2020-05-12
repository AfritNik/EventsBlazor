using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using NI.Helpers.Blazor.Modal;

namespace NikEventBlazor.Client.Shared
{
    public partial class BlazoredModal : IDisposable
    {
        private const string m_defaultStyle = "blazored-modal";
        private const string m_defaultPosition = "blazored-modal-center";

        [Inject] private IModalService ModalService { get; set; }
        [Parameter] public bool ShowHeader { get; set; } = true;
        [Parameter] public bool ShowCloseButton { get; set; } = true;

        [Parameter] public bool DisableBackgroundCancel { get; set; }
        [Parameter] public string Position { get; set; }
        [Parameter] public string Style { get; set; }

        private string ComponentPosition { get; set; }
        private bool ComponentShowHeader { get; set; }
        private string ComponentStyle { get; set; }
        private bool ComponentDisableBackgroundCancel { get; set; }
        private bool ComponentShowButton { get; set; } = true;
        private bool ComponentShowCloseButton { get; set; } = true;

        private bool IsVisible { get; set; }
        private string Title { get; set; }
        private RenderFragment Content { get; set; }
        private ModalParameters Parameters { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            ((ModalService)ModalService).OnShow += ShowModal;
            ((ModalService)ModalService).CloseModal += CloseModal;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private async void ShowModal(string title, RenderFragment content, ModalParameters parameters, ModalOptions options)
        {
            Title = title;
            Content = content;
            IsVisible = true;
            Parameters = parameters;
            SetModalOptions(options);
            Debug.WriteLine($"blazored-modal-container {ComponentPosition} {(IsVisible?"blazored-modal-active": string.Empty)}");
            await InvokeAsync(StateHasChanged);
        }

        private async void CloseModal()
        {
            Title = "";
            Content = null;
            IsVisible = false;
            await InvokeAsync(StateHasChanged);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                ((ModalService) ModalService).OnShow -= ShowModal;
                ((ModalService) ModalService).CloseModal -= CloseModal;
            }
        }

        private void HandleBackgroundClick()
        {
            if (ComponentDisableBackgroundCancel) 
                return;
            ModalService.Cancel();
        }

        private void SetModalOptions(ModalOptions options)
        {
            ComponentShowHeader = ShowHeader;
            if (options.ShowHeader.HasValue)
                ComponentShowHeader = options.ShowHeader.Value;

            ComponentShowCloseButton = ShowCloseButton;
            if (options.ShowCloseButton.HasValue)
                ComponentShowCloseButton = options.ShowCloseButton.Value;

            ComponentDisableBackgroundCancel = DisableBackgroundCancel;
            if (options.DisableBackgroundCancel.HasValue)
                ComponentDisableBackgroundCancel = options.DisableBackgroundCancel.Value;

            ComponentPosition = string.IsNullOrWhiteSpace(options.Position)? Position:options.Position;
            if (string.IsNullOrWhiteSpace(ComponentPosition))
                ComponentPosition = m_defaultPosition;

            ComponentStyle = string.IsNullOrWhiteSpace(options.Style)? Position:options.Style;
            if (string.IsNullOrWhiteSpace(ComponentStyle))
                ComponentStyle = m_defaultStyle;
        }

        public void SetTitle(string title)
        {
            Title = title;
            StateHasChanged();
        }
    }
}

