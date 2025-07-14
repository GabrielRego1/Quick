using Application.Abstractions.Repositories;
using Domain.Entities;
using Infrastructure.SqlServer.Contexts;

namespace Infrastructure.SqlServer.Repositories;

internal class TradeRepository(QuickDbContext context) : Repository<Trade>(context), ITradeRepository;