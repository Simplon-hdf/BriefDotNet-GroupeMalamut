﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIMarcheEtDeviens.Models
{
	public class Participant
	{
		[Key]
		public Guid ParticiperId { get; set; }
		public Guid RandonneurId { get; set; }
		public Guid RandonneeId { get; set; }

		[ForeignKey("RandonneurId")]
		public Randonneur? Randonneur { get; set; }

		[ForeignKey("RandonneeId")]
		public Randonnee? Randonnee { get; set; }
	}
}
