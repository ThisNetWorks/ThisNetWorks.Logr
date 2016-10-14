//in your platform setup class (setup.cs) use this override

		protected override IMvxTrace CreateDebugTrace()
		{
			return new LogrMvxDebugTrace();
		}