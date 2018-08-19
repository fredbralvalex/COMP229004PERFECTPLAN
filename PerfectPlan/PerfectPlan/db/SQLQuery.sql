drop table pp_address;
drop table pp_user;

create table pp_address(
    addressid integer not null,
    streetname varchar(50) not null,
    streetnumber integer not null,
    zipcode varchar(6) not null,
    city varchar(50) not null,
    province varchar(2) not null,
    country varchar(15) not null,
    CONSTRAINT pp_address_pk PRIMARY KEY (addressid)
);
insert into pp_address (addressid, streetname, streetnumber,zipcode,city, province, country) values (1, 'gowan ave', 80, 'm4k2e2', 'Toronto', 'ON', 'Canada');
insert into pp_address (addressid, streetname, streetnumber,zipcode,city, province, country) values (2, 'gowan ave', 100, 'm4k2e2', 'Toronto', 'ON', 'Canada');
insert into pp_address (addressid, streetname, streetnumber,zipcode,city, province, country) values (3, 'gowan ave', 120, 'm4k2e2', 'Toronto', 'ON', 'Canada');

create table pp_user (
    userid integer not null,
    useremail varchar(50) not null,
    userpassword varchar(50) not null,
    usertype char not null,
    CONSTRAINT pp_user_type_ck CHECK (usertype in ('P', 'V')),
    CONSTRAINT pp_user_pk PRIMARY KEY (userid)
) ;
insert into pp_user (userid, useremail, userpassword, usertype) values (1, 'venuehost@email.com','12345678','V');
insert into pp_user (userid, useremail, userpassword, usertype) values (2, 'participant1@email.com','12345678','P');
insert into pp_user (userid, useremail, userpassword, usertype) values (3, 'participant2@email.com','12345678','P');

select * from pp_user;

create table pp_participant (
    participantid integer not null,
    participantname varchar(50) not null,
    userid integer not null,    
    addressid integer not null,
    CONSTRAINT pp_participant_user_uk unique (userid),
    CONSTRAINT pp_participant_pk PRIMARY KEY (participantid),
    CONSTRAINT pp_participant_user_fk FOREIGN KEY (userid) REFERENCES pp_user (userid),    
    CONSTRAINT pp_participant_address_fk FOREIGN KEY (addressid) REFERENCES pp_address (addressid)
);
insert into pp_participant (participantid, participantname, userid, addressid) values (1, 
'participant 1',
(select userid from pp_user where useremail='participant1@email.com'), 
2);
insert into pp_participant (participantid, participantname, userid, addressid) values (2,
'participant 2',
(select userid from pp_user where useremail='participant2@email.com'), 
2);


create table pp_venuehost (
    venuehostid integer not null,
    userid integer not null,
    venuehostname varchar(50) not null,
    subscribed char default '0' not null,
    CONSTRAINT pp_venuehost_user_uk unique (userid),
    CONSTRAINT pp_venuehost_subscribed_ck CHECK (subscribed in ('1', '0')),
    CONSTRAINT pp_venuehost_pk PRIMARY KEY (venuehostid),
    CONSTRAINT pp_venuehost_user_fk FOREIGN KEY (userid) REFERENCES pp_user (userid)
);

insert into pp_venuehost (venuehostid, USERID, VENUEHOSTNAME, SUBSCRIBED) values (1, (select userid from pp_user where useremail='venuehost@email.com'), 'venue host', '1');


create table pp_branch (
    branchid integer not null,
    venuehostid integer not null,
    label varchar(50) not null,
    addressid integer not null,
    CONSTRAINT pp_branch_address_uk unique (addressid),
    CONSTRAINT pp_branch_pk PRIMARY KEY (branchid),
    CONSTRAINT pp_branch_venuehost_fk FOREIGN KEY (venuehostid) REFERENCES pp_venuehost (venuehostid),
    CONSTRAINT pp_branch_address_fk FOREIGN KEY (addressid) REFERENCES pp_address (addressid)
);

select * from pp_branch;
insert into pp_branch (branchid, VENUEHOSTID, ADDRESSID, LABEL) values (1, 1, 1, 'branch 1');

insert into pp_branch (branchid, VENUEHOSTID, ADDRESSID, LABEL) values (2, 1, 3, 'branch 2');

create table pp_event (
    eventid integer not null,
    venuehostid integer not null,
    branchid integer not null,
    description varchar(50) not null,
    eventdate date not null,
    deadline date not null,
    status char default 'O' not null,
    CONSTRAINT pp_event_date_deadline_ck CHECK (eventdate >= deadline),
    CONSTRAINT pp_event_status_ck CHECK (status in ('O', 'G','C','E')),
    CONSTRAINT pp_event_pk PRIMARY KEY (eventid),
    CONSTRAINT pp_event_branch_fk FOREIGN KEY (branchid) REFERENCES pp_branch (branchid)
);

create table pp_budgetitem (
    budgetitemid integer not null,
    eventid integer not null,
    description varchar(50) not null,
    value decimal (7,2) default 0 not null,
    CONSTRAINT pp_budgetitem_pk PRIMARY KEY (budgetitemid, eventid),
    CONSTRAINT pp_budgetitem_event_fk FOREIGN KEY (eventid) REFERENCES pp_event (eventid)
);

--select * from pp_event;
insert into pp_event (VENUEHOSTID, BRANCHID, DESCRIPTION, EVENTDATE, DEADLINE, STATUS) values (1, 2, 'first event', '2018-05-17', '2018-05-17', 'O');
--select * from pp_budgetitem;
insert into pp_budgetitem (BUDGETITEMID, EVENTID, DESCRIPTION, VALUE) values(1, 1, 'budget 1', 500);

create table pp_eventparticipant (
    eventid integer not null, 
    participantid integer not null,
    status varchar(2) default 'PA' not null,
    owner char default '0' not null,
    CONSTRAINT pp_participant_owner_ck CHECK (owner in ('1', '0')),
    CONSTRAINT pp_eventparticipant_status_ck CHECK (status in ('PA', 'NA','OW','SD', 'NP')),
    CONSTRAINT pp_event_participant_pk PRIMARY KEY (eventid, participantid),
    CONSTRAINT pp_eventparticipant_event_fk FOREIGN KEY (eventid) REFERENCES pp_event (eventid),
    CONSTRAINT pp_eparticipant_participant_fk FOREIGN KEY (participantid) REFERENCES pp_participant (participantid)
);

insert into pp_eventparticipant (EVENTID, PARTICIPANTID, STATUS, OWNER)values (1,1,'PA', '0');
insert into pp_eventparticipant (EVENTID, PARTICIPANTID, STATUS, OWNER) values (1,2,'PA', '1');
insert into pp_eventparticipant (EVENTID, PARTICIPANTID, STATUS, OWNER) values (1,3,'PA', '0');


select * from pp_user;
select * from pp_venuehost;
select LOWER(useremail) from pp_user;

select * from pp_user u, pp_participant p where p.userid = u.userid and u.userid = 2;
select * from pp_participant;
select * from pp_eventparticipant;
select * from pp_user u, pp_participant p 
where p.userid = u.userid and u.userid = 2;

select * from pp_user u, pp_participant p, pp_event e, pp_eventparticipant ep 
where e.eventid = ep.eventid and p.participantid = ep.participantid
and p.userid = u.userid and u.userid = 2;

select * from pp_user u, pp_participant p, pp_event e, pp_eventparticipant ep 
where e.eventid = ep.eventid and p.participantid = ep.participantid
and p.userid = u.userid and e.eventid= 6;

select participantname as 'Participant Name', ep.status as 'Participant Status', ep.owner as Owner 
                    from pp_eventparticipant ep, pp_participant p where p.participantid=ep.participantid and ep.eventid = 6;



select * from pp_event;
select * from pp_user u, pp_participant p where u.userid = p.userid;

SELECT streetname, streetnumber, zipcode, city, province, country
FROM pp_branch b, pp_address a
where a.addressid = b.addressid and b.[branchid] = 1;

select * from pp_budgetitem;