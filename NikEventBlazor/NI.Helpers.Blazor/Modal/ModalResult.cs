using System;
using System.Collections.Generic;
using System.Text;

namespace NI.Helpers.Blazor.Modal
{
    public class ModalResult
    {
        public object Data { get; }
        public Type DataType { get; }
        public bool Cancelled { get; }
        public Type ModalType { get; set; }

        protected ModalResult(object data, Type dataType, bool cancelled, Type modalType)
        {
            Data = data;
            DataType = dataType;
            Cancelled = cancelled;
            ModalType = modalType;
        }

        public static ModalResult Ok<T>(T result) => Ok(result, default);
        public static ModalResult Ok<T>(T result, Type modalType) => new ModalResult(result, typeof(T), false, modalType);
        public static ModalResult Cancel() => Cancel(default);
        public static ModalResult Cancel(Type modalType) => new ModalResult(default, typeof(object), true, modalType);

    }
}
