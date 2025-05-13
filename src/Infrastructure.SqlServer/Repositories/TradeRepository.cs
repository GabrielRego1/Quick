using Application.Abstractions.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.SqlServer.Repositories;

internal class TradeRepository(DbContext context) : Repository<Trade>(context), ITradeRepository;