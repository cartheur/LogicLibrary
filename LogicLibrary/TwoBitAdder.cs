﻿namespace LogicLibrary
{
	public class TwoBitAdder : Circuit
	{
		public FullAdder adder1;
		public FullAdder adder2;

		public Wire Cin { get; set; } = new Wire { CircuitName = "Cin" };
		public Wire A0 { get; set; } = new Wire { CircuitName = "A0" };
		public Wire B0 { get; set; } = new Wire { CircuitName = "B0" };
		public Wire A1 { get; set; } = new Wire { CircuitName = "A1" };
		public Wire B1 { get; set; } = new Wire { CircuitName = "B1" };

		public double F0(int timing)
		{
			RunIteration(timing);

			return adder1.S(timing);
		}

		public double F1(int timing)
		{
			RunIteration(timing);
			adder2.Cin.Add(adder1.Cout(timing));

			return adder2.S(timing);
		}

		public double Cout(int timing)
		{
			RunIteration(timing);
			adder2.Cin.Add(adder1.Cout(timing));

			return adder2.Cout(timing);
		}

		public TwoBitAdder(TTLGateTypeEnum gateTypes)
		{
			Name = "2-bit adder";

			adder1 = new FullAdder(gateTypes);
			adder2 = new FullAdder(gateTypes);

			adder1.Name = "Full Adder #1";
			adder2.Name = "Full Adder #2";

			// inputs
			Connections.Add(new Connection
			{
				Source = Cin,
				WireTermination = adder1.Cin,
				Name = "Cin -> adder1.Cin"
			});

			Connections.Add(new Connection
			{
				Source = A0,
				WireTermination = adder1.A,
				Name = "A0 -> adder1.A"
			});

			Connections.Add(new Connection
			{
				Source = B0,
				WireTermination = adder1.B,
				Name = "B0 -> adder1.B"
			});

			Connections.Add(new Connection
			{
				Source = A1,
				WireTermination = adder2.A,
				Name = "A1 -> adder2.A"
			});

			Connections.Add(new Connection
			{
				Source = B1,
				WireTermination = adder2.B,
				Name = "B1 -> adder2.B"
			});
		}
	}
}
