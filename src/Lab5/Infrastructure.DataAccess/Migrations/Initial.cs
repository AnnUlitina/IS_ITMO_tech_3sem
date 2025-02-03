using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace Infrastructure.DataAccess.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
        """
    if not exists (select 1 from pg_type where typename = 'user_role') then
    create type user_role as enum
    (
        'none',
        'admin',
        'customer'
    );
    end if;
    end$$;

    create table if not exists users
    (
        user_id bigint primary key generated always as identity,
        user_name text not null,
        user_role user_role not null,
        user_password text not null
    );

    create table if not exists cards
    (
        card_id bigint primary key generated always as identity,
        card_name text not null,
        owner_card_id bigint not null references users(user_id),
        card_password text not null,
        card_bill integer
    );

    create table if not exists transactions
    (
        card_id bigint not null references cards(card_id),
        transaction_name text not null,
        transaction_date text not null,
        primary key (card_id, transaction_name)
    );
    """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
        """
        drop table users;
        drop table cards
        drop table transactions

        drop type user_role;
        """;
}