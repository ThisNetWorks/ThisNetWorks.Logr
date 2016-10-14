//in your platform setup class use this override

		protected override IMvxTrace CreateDebugTrace()
		{
			return new LogrMvxDebugTrace();
		}