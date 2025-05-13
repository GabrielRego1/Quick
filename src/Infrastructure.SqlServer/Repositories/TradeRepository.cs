using Application.Abstractions.Repositories;
using Domain.Entities;
using Infrastructure.SqlServer.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.SqlServer.Repositories;

internal class TradeRepository(QuickDbContext context) : Repository<Trade>(context), ITradeRepository;