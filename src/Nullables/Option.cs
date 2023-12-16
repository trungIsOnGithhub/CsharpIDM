namespace Nullables
{
    class Option<T> where T : notnull
    {
        public static Option<T> None() => default;
        public static Option<T> Some(T value) => new Option<T>(value);

        readonly T value;
        readonly bool isSome;

        internal Option(T value)
        {
            this.value = value;
            this.isSome = this.value is T;
        }

        public bool IsSome(out T value)
        {
            value = this.value;
            return this.isSome;
        }
    }

}